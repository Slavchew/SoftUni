using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKaraoke
{
    class SoftUniKaraoke
    {
        static void Main(string[] args)
        {
            var participants = Console.ReadLine().Split(", ").ToList();
            var songs = Console.ReadLine().Split(", ").ToList();

            var winners = new Dictionary<string, List<string>>();

            var command = Console.ReadLine().Split(", ");
            while (command[0] != "dawn")
            {
                var participant = command[0];
                var song = command[1];
                var award = command[2];
                if (participants.Contains(participant) && songs.Contains(song))
                {
                    if (winners.ContainsKey(participant))
                    {
                        if (!winners[participant].Contains(award))
                        {
                            winners[participant].Add(award);
                        }
                    }
                    else
                    {
                        winners[participant] = new List<string>();
                        winners[participant].Add(award);
                    }
                }
                command = Console.ReadLine().Split(", ");
            }

            var result = winners.OrderByDescending(x => x.Value.Count).ThenBy(n => n.Key);

            if (result.Count() > 0)
            {
                foreach (var winner in result)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"{winner.Key}: {winner.Value.Count} awards");
                    foreach (var award in winner.Value.OrderBy(x => x))
                    {
                        sb.AppendLine($"--{award}");
                    }
                    Console.WriteLine(sb.ToString().Trim());
                }
            }
            else
            {
                Console.WriteLine("No awards");
            }
        }
    }
}
