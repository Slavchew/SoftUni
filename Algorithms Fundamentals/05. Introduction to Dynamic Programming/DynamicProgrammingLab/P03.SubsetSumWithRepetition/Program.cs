
using System;

namespace P03.SubsetSumWithRepetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = new[] { 3, 2, 5 };
            var target = 14;

            var sums = new bool[target + 1];
            sums[0] = true;

            for (int sum = 0; sum < sums.Length; sum++)
            {
                if (sums[sum])
                {
                    foreach (int num in nums)
                    {
                        var newSum = sum + num;

                        if (newSum <= target)
                        {
                            sums[newSum] = true;
                        }
                    }
                }
            }

            while (target> 0)
            {
                foreach (var num in nums)
                {
                    var prev = target - num;
                    if (prev >= 0 && sums[prev])
                    {
                        Console.WriteLine(num);
                        target = prev;
                    }
                }
            }
        }
    }
}
