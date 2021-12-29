using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Raincast
{
    class Raincast
    {
        static void Main(string[] args)
        {
            List<string> raincasts = new List<string>();

            var line = Console.ReadLine();
            var currCommand = "Type";
            var result = new List<string>();

            while (line != "Davai Emo")
            {
                var input = line.Split(':').ToArray();
                var command = input[0];
                if (command == "Type" && command == currCommand)
                {
                    var type = input[1].TrimStart();
                    if (type == "Normal" || type == "Warning" || type == "Danger")
                    {
                        result.Add(type);
                        currCommand = "Source";
                    }
                }
                else if (command == "Source" && command == currCommand)
                {
                    var source = input[1].TrimStart();
                    if (Regex.IsMatch(source, "^[a-zA-Z0-9]*$"))
                    {
                        result.Add(source);
                        currCommand = "Forecast";
                    }
                }
                else if (command == "Forecast" && command == currCommand)
                {
                    var forecast = input[1].TrimStart();

                    bool isContains = forecast.Contains('!') || forecast.Contains('.') 
                                    || forecast.Contains(',') || forecast.Contains('?');
                    if (!isContains)
                    {
                        var raincast = $"({result[0]}) {forecast} ~ {result[1]}";
                        raincasts.Add(raincast);
                        result.Clear();

                        currCommand = "Type";
                    }
                }


                line = Console.ReadLine();
            }

            foreach (var raincast in raincasts)
            {
                Console.WriteLine(raincast);
            }
        }
    }
}
