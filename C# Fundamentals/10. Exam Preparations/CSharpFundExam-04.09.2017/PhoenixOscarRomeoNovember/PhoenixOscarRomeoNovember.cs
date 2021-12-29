using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixOscarRomeoNovember
{
    class PhoenixOscarRomeoNovember
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var squads = new Dictionary<string, List<string>>();

            while (input != "Blaze it!")
            {
                input = input.Replace(" -> ", " ");
                var playerInfo = input.Split(' ').ToArray();
                var creature = playerInfo[0];
                var squadMate = playerInfo[1];
                if (creature != squadMate)
                {
                    if (!squads.ContainsKey(creature))
                        squads.Add(creature, new List<string>() { squadMate });
                    else if (!squads[creature].Contains(squadMate))
                        squads[creature].Add(squadMate);
                }

                input = Console.ReadLine();
            }

            var result = new Dictionary<string, List<string>>();
            foreach (var creature in squads)
            {
                var list = new List<String>();
                foreach (var mate in creature.Value)
                {
                    if (squads.ContainsKey(mate))
                        if (squads[mate].Contains(creature.Key))
                            continue;
                    list.Add(mate);
                }
                result.Add(creature.Key, list);
            }

            var sorted = result.OrderByDescending(x => x.Value.Count());

            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.Key} : {item.Value.Count}");
            }
        }
    }
}
