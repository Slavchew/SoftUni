using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundingNums
{
    class RoundingNums
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                 int roundedNums = (int)Math.Round(nums[i], MidpointRounding.AwayFromZero);
                 Console.WriteLine($"{nums[i]} => {roundedNums}");
            }
        }
    }
}
