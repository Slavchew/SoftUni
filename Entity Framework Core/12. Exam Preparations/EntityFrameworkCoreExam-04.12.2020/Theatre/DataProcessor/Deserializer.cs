namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();

            var plays = XmlConverter.Deserializer<PlayXmlInputModel>(xmlString, "Plays");

            foreach (var xmlPlay in plays)
            {
                TimeSpan duration = TimeSpan.ParseExact(xmlPlay.Duration, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);

                bool isValidGenre = Enum.TryParse<Genre>(xmlPlay.Genre, out Genre genre);

                if (!IsValid(xmlPlay) || duration.Hours < 1 || !isValidGenre)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play
                {
                    Title = xmlPlay.Title,
                    Duration = duration,
                    Rating = xmlPlay.Rating,
                    Genre = genre,
                    Description = xmlPlay.Description,
                    Screenwriter = xmlPlay.Screenwriter,
                };

                context.Plays.Add(play);
                context.SaveChanges();
                output.AppendLine(String.Format(SuccessfulImportPlay, play.Title, play.Genre, play.Rating));
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();

            var casts = XmlConverter.Deserializer<CastXmlInputModel>(xmlString, "Casts");

            foreach (var xmlcast in casts)
            {
                if (!IsValid(xmlcast))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast
                {
                    FullName = xmlcast.FullName,
                    IsMainCharacter = xmlcast.IsMainCharacter,
                    PhoneNumber = xmlcast.PhoneNumber,
                    PlayId = xmlcast.PlayId,
                };

                context.Casts.Add(cast);
                context.SaveChanges();
                output.AppendLine(String.Format(SuccessfulImportActor, 
                    cast.FullName, 
                    cast.IsMainCharacter ? "main" : "lesser"));
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();

            var theatres = JsonConvert.DeserializeObject<IEnumerable<TheatreInputModel>>(jsonString);
            foreach (var jsonTheatre in theatres)
            {
                if (!IsValid(jsonTheatre))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                List<TicketInputModel> validTickets = new List<TicketInputModel>();

                foreach (var ticket in jsonTheatre.Tickets)
                {
                    if (IsValid(ticket))
                    {
                        validTickets.Add(ticket);
                    }
                    else
                    {
                        output.AppendLine(ErrorMessage);
                    }
                }

                Theatre theatre = new Theatre
                {
                    Name = jsonTheatre.Name,
                    NumberOfHalls = jsonTheatre.NumberOfHalls,
                    Director = jsonTheatre.Director,
                    Tickets = validTickets.Select(t => new Ticket
                    {
                        Price = t.Price,
                        RowNumber = t.RowNumber,
                        PlayId = t.PlayId,
                    })
                    .ToList(),
                };

                context.Theatres.Add(theatre);
                context.SaveChanges();
                output.AppendLine(String.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count()));
            }

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
