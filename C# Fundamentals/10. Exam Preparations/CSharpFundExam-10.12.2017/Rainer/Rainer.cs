using System;
using System.Collections.Generic;
using System.Linq;

namespace Rainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var index = input[input.Count - 1];
            input.RemoveAt(input.Count - 1);

            bool isLossing = false;
            var steps = 0;
            var sequance = new List<int>();
            sequance.AddRange(input);

            while (isLossing != true)
            {
                DecreaseValue(sequance);
                if (sequance[index] == 0)
                {
                    Console.WriteLine(string.Join(" ",sequance));
                    Console.WriteLine(steps);
                    break;
                }

                index = int.Parse(Console.ReadLine());

                if (sequance.Contains(0))
                {
                    ReternValue(sequance, input);
                }

                steps++;
            }
        }

        private static List<int> ReternValue(List<int> sequance, List<int> input)
        {
            for (int i = 0; i < sequance.Count; i++)
            {
                if (sequance[i] == 0)
                {
                    sequance[i] = input[i];
                }
            }

            return sequance;
        }

        public static List<int> DecreaseValue(List<int> sequance)
        {
            for (int i = 0; i < sequance.Count; i++)
            {
                sequance[i]--;
            }
            return sequance;
        }
    }
}
