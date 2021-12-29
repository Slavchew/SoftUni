using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizeWords
{
    class RandomizeWords
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var list = Console.ReadLine().Split(' ').ToList();

            for (int i = 0; i < list.Count; i++)
            {
                var randomIndex = random.Next(0, list.Count);

                var randomEl = list[randomIndex];
                var el = list[i];

                list[randomIndex] = el;
                list[i] = randomEl;
            }
            foreach (var num in list)
            {
                Console.WriteLine(num);
            }
        }
    }
}
