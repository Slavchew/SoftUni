using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddMeetings
{
    class OddMeetings
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToLower().Split(' ');
            var count = new Dictionary<string, int>();
            foreach (var word in input)
            {
                if (count.ContainsKey(word))
                    count[word]++;
                else
                    count[word] = 1;
            }

            var result = new List<string>();
            foreach (var pair in count)
            {
                if (pair.Value % 2 != 0)
                {
                    result.Add(pair.Key);
                }
            }
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
