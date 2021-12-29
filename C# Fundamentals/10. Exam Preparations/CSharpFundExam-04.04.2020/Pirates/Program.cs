using System;
using System.Collections.Generic;
using System.Linq;

namespace Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> towns = new Dictionary<string, Dictionary<string, int>>();

            var command = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Sail")
            {
                var town = command[0];
                var population = int.Parse(command[1]);
                var gold = int.Parse(command[2]);
                if (towns.ContainsKey(town))
                {
                    towns[town]["population"] += population;
                    towns[town]["gold"] += gold;
                }
                else
                {
                    towns.Add(town, new Dictionary<string, int>()
                    {
                        {"population", population},
                        {"gold", gold}
                    });
                }
                command = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries);
            }

            command = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "End")
            {
                var cmdType = command[0];
                var town = command[1];
                if (cmdType == "Plunder")
                {
                    var population = int.Parse(command[2]);
                    var gold = int.Parse(command[3]);

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {population} citizens killed.");

                    towns[town]["population"] -= population;
                    towns[town]["gold"] -= gold;
                    if (towns[town]["population"] <= 0 || towns[town]["gold"] <= 0)
                    {
                        Console.WriteLine($"{town} has been wiped off the map!");
                        towns.Remove(town);
                    }
                    
                }
                else if (cmdType == "Prosper")
                {
                    var gold = int.Parse(command[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        towns[town]["gold"] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {towns[town]["gold"]} gold.");
                    }
                }


                command = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
            }

            if (towns.Count > 0)
            {
                towns = towns
                    .OrderByDescending(x => x.Value["gold"])
                    .ThenBy(t => t.Key)
                    .ToDictionary(k => k.Key, v => v.Value);

                Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");
                foreach (var town in towns)
                {
                    var population = town.Value["population"];
                    var gold = town.Value["gold"];
                    Console.WriteLine($"{town.Key} -> Population: {population} citizens, Gold: {gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
