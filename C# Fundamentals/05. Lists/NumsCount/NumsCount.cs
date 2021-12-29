using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumsCount
{
    class NumsCount
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var counts = new int[nums.Max() + 1];
            foreach (var num in nums)
                counts[num]++;
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > 0)
                    Console.WriteLine($"{i} -> {counts[i]}");
            }
        }
    }
}
