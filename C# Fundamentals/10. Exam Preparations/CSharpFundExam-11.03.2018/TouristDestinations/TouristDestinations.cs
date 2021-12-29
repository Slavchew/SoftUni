using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TouristDestinations
{
    class TouristDestinations
    {
        static void Main(string[] args)
        {
            var countries = new Dictionary<string, List<string>>();

            var input = Console.ReadLine().Split(" ").ToList();

            while (input[0] != "End")
            {
                var command = input[0];
                if (command == "Add")
                {
                    var country = input[1];
                    var city = input[2];
                    if (countries.ContainsKey(country))
                    {
                        countries[country].Add(city);
                    }
                    else
                    {
                        countries[country] = new List<string>();
                        countries[country].Add(city);
                    }
                }
                else if (command == "Remove")
                {
                    var city = input[1];
                    bool isTownExist = false;
                    foreach (var country in countries)
                    {
                        if (country.Value.Contains(city))
                        {
                            isTownExist = true;
                            country.Value.Remove(city);
                        }
                    }

                    if (!isTownExist)
                    {
                        Console.WriteLine($"City {city} not found");
                    }
                }


                input = Console.ReadLine().Split(" ").ToList();
            }

            var result = countries.OrderByDescending(x => x.Value.Count).ThenBy(a => a.Key);

            foreach (var country in result)
            {
                //{country} has {cities count} cities and they are: {city1}, {city2}
                Console.WriteLine($"{country.Key} has {country.Value.Count} cities and they are: {string.Join(", ", country.Value)}");
            }
        }
    }
}
