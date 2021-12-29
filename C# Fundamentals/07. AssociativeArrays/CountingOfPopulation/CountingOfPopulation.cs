using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingOfPopulation
{
    class CountingOfPopulation
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split('|').ToList();

            var countries = new Dictionary<string, Dictionary<string, long>>();

            while (input[0] != "report")
            {
                var country = input[1];
                var town = input[0];
                var count = long.Parse(input.Last());

                if (countries.ContainsKey(country))
                {
                    if (countries[country].ContainsKey(town))
                    {
                        countries[country][town] += count;
                    }
                    else
                    {
                        countries[country][town] = count;
                    }
                }
                else
                {
                    countries[country] = new Dictionary<string, long>() { { town, count } };
                }

                input = Console.ReadLine().Split('|').ToList();
            }

            var populationDataSorted = countries
               .OrderByDescending(x => x.Value.Values.Sum())
               .ToDictionary(x => x.Key, x => x.Value);

            foreach (var country in populationDataSorted)
            {
                var totalPopulation = country.Value.Select(x => x.Value).Sum();
                Console.WriteLine($"{country.Key} (total population: {totalPopulation})");

                var citiesSorted = country.Value.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                foreach (var town in citiesSorted)
                {
                    Console.WriteLine($"=>{town.Key}: {town.Value}");
                }
            }

        }
    }
}
