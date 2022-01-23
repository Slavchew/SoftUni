namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder output = new StringBuilder();

			var games = JsonConvert.DeserializeObject<IEnumerable<GameImportModel>>(jsonString);
			foreach (var jsonGame in games)
            {
                bool isValidReleaseDate = DateTime.TryParseExact(jsonGame.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

                if (!IsValid(jsonGame) || jsonGame.Tags.Count() == 0 || !isValidReleaseDate)
                {
					output.AppendLine("Invalid Data");
					continue;
                }

                Developer developer = context.Developers.FirstOrDefault(x => x.Name == jsonGame.Developer)
					?? new Developer { Name = jsonGame.Developer };

                Genre genre = context.Genres.FirstOrDefault(x => x.Name == jsonGame.Genre)
					?? new Genre { Name = jsonGame.Genre };

				var game = new Game
				{
					Name = jsonGame.Name,
					Price = jsonGame.Price,
					ReleaseDate = releaseDate,
					Developer = developer,
					Genre = genre,
				};

				foreach (var jsonTag in jsonGame.Tags)
                {
					var tag = context.Tags.FirstOrDefault(x => x.Name == jsonTag)
						?? new Tag { Name = jsonTag };
					game.GameTags.Add(new GameTag { Tag = tag });
                }

				context.Games.Add(game);
				context.SaveChanges();
				output.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

			return output.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder output = new StringBuilder();

			var users = JsonConvert.DeserializeObject<IEnumerable<UserImportModel>>(jsonString);

			foreach (var jsonUser in users)
            {
                if (!IsValid(jsonUser) || !jsonUser.Cards.All(IsValid))
                {
					output.AppendLine("Invalid Data");
					continue;
				}

				User user = new User
                {
					Age = jsonUser.Age,
					Email = jsonUser.Email,
					FullName = jsonUser.FullName,
					Username = jsonUser.Username,
					Cards = jsonUser.Cards.Select(x => new Card 
					{
						Cvc = x.CVC,
						Number = x.Number,
						Type = x.Type.Value,
                    })
					.ToList(),
                };

				context.Users.Add(user);
				context.SaveChanges();
				output.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

			return output.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			StringBuilder output = new StringBuilder();

			var xmlSerializer = new XmlSerializer(typeof(PurchaseImportModel[]),
				new XmlRootAttribute("Purchases"));

			var purchases = (PurchaseImportModel[])xmlSerializer.Deserialize(new StringReader(xmlString));

			foreach (var xmlPurchase in purchases)
            {
				bool isValidDate = DateTime.TryParseExact(xmlPurchase.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

				if (!IsValid(xmlPurchase) || !isValidDate)
                {
					output.AppendLine("Invalid Data");
					continue;
				}

				Game game = context.Games.FirstOrDefault(x => x.Name == xmlPurchase.GameName);

				Card card = context.Cards.FirstOrDefault(x => x.Number == xmlPurchase.Card);

                Purchase purchase = new Purchase
				{
					Game = game,
					Type = xmlPurchase.Type.Value,
					ProductKey = xmlPurchase.Key,
					Card = card,
					Date = date,
				};

				context.Purchases.Add(purchase);
				context.SaveChanges();

				output.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
			}

			return output.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}