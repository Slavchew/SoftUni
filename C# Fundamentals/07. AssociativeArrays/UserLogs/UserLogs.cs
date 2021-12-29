using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogs
{
    class UserLogs
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ', '=' }).ToList();

            var persons = new SortedDictionary<string, Dictionary<string, int>>();

            while (input[0] != "end")
            {
                var user = input.Last();
                var ip = input[1];

                if (persons.ContainsKey(user))
                {
                    if (persons[user].ContainsKey(ip))
                    {
                        persons[user][ip]++;
                    }
                    else
                    {
                        persons[user][ip] = 1;
                    }
                }
                else
                {
                    persons[user] = new Dictionary<string, int>() { { ip, 1 } };
                }


                input = Console.ReadLine().Split(new char[] { ' ', '=' }).ToList();
            }

            foreach (var person in persons)
            {
                Console.WriteLine(person.Key + ":");
                Console.WriteLine(string.Join(", ",person.Value.Select(x => x.Key + " => " + x.Value)) + ".");
            }
        }
    }
}
