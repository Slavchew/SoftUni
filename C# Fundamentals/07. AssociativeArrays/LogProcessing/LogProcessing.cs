using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProcessing
{
    class LogProcessing
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var logs = new SortedDictionary<string, SortedDictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ').ToList();
                var user = input[1];
                var ip = input[0];
                var duration = int.Parse(input[2]);

                if (logs.ContainsKey(user))
                {
                    if (logs[user].ContainsKey(ip))
                    {
                        logs[user][ip] += duration;
                    }
                    else
                    {
                        logs[user][ip] = duration;
                    }
                }
                else
                {
                    logs[user] = new SortedDictionary<string, int>() { { ip, duration } };
                }
            }

            foreach (var user in logs)
            {
                var totalDuration = user.Value.Select(x => x.Value).Sum();
                Console.Write($"{user.Key}: {totalDuration} ");

                Console.WriteLine("[" + string.Join(", ", user.Value.Keys) + "]");
            }
        }
    }
}
