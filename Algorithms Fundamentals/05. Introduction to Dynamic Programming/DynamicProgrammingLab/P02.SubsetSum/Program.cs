using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.SubsetSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = new[] { 3, 5, 1, 4, 2 };
            var target = 13;

            var sums = GetAllSums(nums);

            if (!sums.ContainsKey(target))
            {
                Console.WriteLine("Sum is not existing");
            }
            else
            {
                while (target != 0)
                {
                    var number = sums[target];
                    target -= number;

                    Console.WriteLine(number);
                }
            }
        }

        private static Dictionary<int, int> GetAllSums(int[] nums)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };

            foreach (int num in nums)
            {
                var currentSums = sums.Keys.ToArray();
                foreach (var sum in currentSums)
                {
                    var newSum = sum + num;

                    if (!sums.ContainsKey(newSum))
                    {
                        sums.Add(newSum, num);
                    }
                }
            }

            return sums;
        }
    }
}
