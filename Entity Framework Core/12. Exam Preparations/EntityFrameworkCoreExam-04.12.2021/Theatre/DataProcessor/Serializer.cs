namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var data = context.Theatres
                .ToList()
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count >= 20)
                .Select(x => new
                {
                    Name = x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x.Tickets.Where(t => t.RowNumber <= 5).Sum(t => t.Price),
                    Tickets = x.Tickets
                    .Where(t => t.RowNumber <= 5)
                    .Select(t => new
                    {
                        Price = t.Price,
                        RowNumber = t.RowNumber
                    }).OrderByDescending(t => t.Price).ToList()
                })
                .OrderByDescending(x => x.Halls)
                .ThenBy(x => x.Name);

            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var data = context.Plays.ToArray()
                .Where(x => x.Rating <= rating)
                .Select(x => new PlayXmlExportModel
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString("c"),
                    Rating = x.Rating == 0 ? "Premier" : x.Rating.ToString(),
                    Genre = x.Genre.ToString(),
                    Actors = x.Casts.Where(c => c.IsMainCharacter == true)
                    .Select(c => new ActorXmlExportModel
                    {
                        FullName = c.FullName,
                        MainCharacter = $"Plays main character in '{x.Title}'."
                    })
                    .OrderByDescending(c => c.FullName)
                    .ToArray()
                })
                .OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .ToArray();

            return XmlConverter.Serialize(data, "Plays");
        }
    }
}
