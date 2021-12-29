using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Race
    {
        static void Main(string[] args)
        {
            var listOfPeople = Console.ReadLine().Split(", ");

            var names = new Dictionary<string, int>();
            foreach (var name in listOfPeople)
            {
                names[name] = 0;
            }

            string namePattern = @"[\W\d]";
            string numberPattern = @"[\WA-Za-z]";

            string input = Console.ReadLine();
            while (input != "end of race")
            {
                string name = Regex.Replace(input, namePattern, "");
                string numbers = Regex.Replace(input, numberPattern, "");

                if (names.ContainsKey(name))
                {
                    var distance = 0;
                    foreach (var digit in numbers)
                    {
                        int currDigit = int.Parse(digit.ToString());
                        distance += currDigit;
                    }
                    names[name] += distance;
                }
                input = Console.ReadLine();
            }

            int count = 1;
            var result = names.OrderByDescending(x => x.Value);
            foreach (var name in result)
            {
                if (count > 3)
                {
                    break;
                }
                string text = count == 1 ? "st" : count == 2 ? "nd" : "rd";

                Console.WriteLine($"{count}{text} place: {name.Key}");
                count++;
            }
        }
    }
}
