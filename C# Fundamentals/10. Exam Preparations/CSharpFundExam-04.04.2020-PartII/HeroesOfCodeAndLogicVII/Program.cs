using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> heroes = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                var heroesStats = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                var heroName = heroesStats[0];
                var heroHP = int.Parse(heroesStats[1]);
                var heroMP = int.Parse(heroesStats[2]);

                if (!heroes.ContainsKey(heroName))
                {
                    heroes.Add(heroName, new Dictionary<string, int>()
                    {
                        {"hp", heroHP },
                        {"mp", heroMP }
                    });
                }
                else
                {
                    heroes[heroName]["hp"] += heroHP;
                    heroes[heroName]["mp"] += heroMP;
                }
            }

            var command = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToList();
            while (command[0] != "End")
            {
                var commandType = command[0];
                var heroName = command[1];

                if (commandType == "CastSpell")
                {
                    var mpNeeded = int.Parse(command[2]);
                    var spellName = command[3];

                    if (heroes[heroName]["mp"] >= mpNeeded)
                    {
                        heroes[heroName]["mp"] -= mpNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName]["mp"]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (commandType == "TakeDamage")
                {
                    var damage = int.Parse(command[2]);
                    var attacker = command[3];

                    if (heroes[heroName]["hp"] > damage)
                    {
                        heroes[heroName]["hp"] -= damage;
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName]["hp"]} HP left!");
                    }
                    else
                    {
                        heroes.Remove(heroName);
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }

                }
                else if (commandType == "Recharge")
                {
                    var amount = int.Parse(command[2]);
                    heroes[heroName]["mp"] += amount;
                    var mpRecovered = 0;
                    if (heroes[heroName]["mp"] > 200)
                    {
                        var tempMP = heroes[heroName]["mp"];
                        var temp = tempMP - 200;
                        mpRecovered = amount - temp;
                        heroes[heroName]["mp"] = 200;
                    }
                    else
                    {
                        mpRecovered = amount;
                    }
                    Console.WriteLine($"{heroName} recharged for {mpRecovered} MP!");
                }
                else if (commandType == "Heal")
                {
                    var amount = int.Parse(command[2]);
                    heroes[heroName]["hp"] += amount;
                    var hpRecovered = 0;
                    if (heroes[heroName]["hp"] > 100)
                    {
                        var tempHP = heroes[heroName]["hp"];
                        var temp = tempHP - 100;
                        hpRecovered = amount - temp;
                        heroes[heroName]["hp"] = 100;
                    }
                    else
                    {
                        hpRecovered = amount;
                    }
                    Console.WriteLine($"{heroName} healed for {hpRecovered} HP!");
                }

                command = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            var result = heroes.OrderByDescending(x => x.Value["hp"]).ThenBy(a => a.Key);

            foreach (var hero in result)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(hero.Key);
                sb.AppendLine($"  HP: {hero.Value["hp"]}");
                sb.AppendLine($"  MP: {hero.Value["mp"]}");

                Console.WriteLine(sb.ToString().Trim());
            }
        }
    }
}
