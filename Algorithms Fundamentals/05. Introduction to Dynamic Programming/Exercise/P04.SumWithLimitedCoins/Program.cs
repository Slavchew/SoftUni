using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.SumWithLimitedCoins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var presents = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var target = int.Parse(Console.ReadLine());

            var sums = CalsSums(presents);

            Console.WriteLine(sums[target]);
        }

        private static Dictionary<int, int> CalsSums(int[] numbers)
        {
            var result = new Dictionary<int, int> { { 0, 1 } };

            foreach (var number in numbers)
            {
                var sums = result.Keys.ToArray();
                foreach (var sum in sums)
                {
                    var newSum = sum + number;

                    if (!result.ContainsKey(newSum))
                    {
                        result.Add(newSum, 1);
                    }
                    else
                    {
                        result[newSum]++;
                    }
                }
            }

            return result;
        }
    }
}
