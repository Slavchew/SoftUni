using System;
using System.Text.RegularExpressions;

namespace Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<day>(?:0[1-9])|(?:[1-2][0-9])|(?:3[0-1]))([\.\-\/])(?<month>[A-Z][a-z]{2})\2(?<year>[0-9]{4})";
            var input = Console.ReadLine();

            var matches = Regex.Matches(input, pattern, RegexOptions.Multiline);

            foreach (Match match in matches)
            {
                var day = match.Groups["day"].Value;
                var month = match.Groups["month"].Value;
                var year = match.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }


        }
    }
}
