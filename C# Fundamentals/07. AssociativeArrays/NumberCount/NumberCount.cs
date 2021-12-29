using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberCount
{
    class NumberCount
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var count = new SortedDictionary<double, int>();
            foreach (var word in input)
            {
                if (count.ContainsKey(word))
                    count[word]++;
                else
                    count[word] = 1;
            }

            foreach (var pair in count)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
