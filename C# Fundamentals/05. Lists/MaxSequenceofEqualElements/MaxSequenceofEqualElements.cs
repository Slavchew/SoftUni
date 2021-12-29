using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSequenceofEqualElements
{
    class MaxSequenceofEqualElements
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var count = 1;
            var bestLength = 1;
            var bestStart = 0;
            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i - 1] == nums[i])
                    count++;
                else
                    count = 1;
                if (count > bestLength)
                {
                    bestLength = count;
                    bestStart = i - count + 1;
                }
            }
            for (int i = bestStart; i < bestStart + bestLength; i++)
                Console.Write($"{nums[i]} ");
            Console.WriteLine();
        }
    }
}
