namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var genres = context.Genres
				.ToList()
				.Where(x => genreNames.Contains(x.Name))
				.Select(x => new
				{
					Id = x.Id,
					Genre = x.Name,
					Games = x.Games.Select(g => new
					{
						Id = g.Id,
						Title = g.Name,
						Developer = g.Developer.Name,
						Tags = string.Join(", ", g.GameTags.Select(gt => gt.Tag.Name)),
						Players = g.Purchases.Count(),
					})
					.Where(g => g.Players > 0)
					.OrderByDescending(g => g.Players)
					.ThenBy(g => g.Id),
					TotalPlayers = x.Games.Sum(g => g.Purchases.Count()),
				})
				.OrderByDescending(x => x.TotalPlayers)
				.ThenBy(x => x.Id);

			return JsonConvert.SerializeObject(genres, Formatting.Indented);
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			var users = context.Users
				.ToList()
				.Where(x => x.Cards.Any(c => c.Purchases.Any(p => p.Type.ToString() == storeType)))
				.Select(x => new UserXmlExportModel
				{
					Username = x.Username,
					TotalSpent = x.Cards
						.Sum(c => c.Purchases.Where(p => p.Type.ToString() == storeType)
						.Sum(p => p.Game.Price)),
					Purchases = x.Cards.SelectMany(c => c.Purchases)
					.Where(p => p.Type.ToString() == storeType)
					.Select(p => new PurchaseXmlExportModel
					{
						Card = p.Card.Number,
						Cvc = p.Card.Cvc,
						Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
						Game = new GameXmlExportModel
						{
							Title = p.Game.Name,
							Genre = p.Game.Genre.Name,
							Price = p.Game.Price
						}
					})
					.OrderBy(p => p.Date)
					.ToArray()
				})
				.OrderByDescending(x => x.TotalSpent)
				.ThenBy(x => x.Username)
				.ToArray();


			var xmlSerializer = new XmlSerializer(typeof(UserXmlExportModel[]), new XmlRootAttribute("Users"));

			XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
			ns.Add("", "");

			var sw = new StringWriter();
			xmlSerializer.Serialize(sw, users, ns);

			return sw.ToString().TrimEnd();
		}
	}
}