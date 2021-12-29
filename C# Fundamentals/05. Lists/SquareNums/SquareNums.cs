using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareNums
{
    class SquareNums
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> squareNums = new List<int>();
            for (int i = 0; i < nums.Count; i++)
            {
                if (Math.Sqrt(nums[i]) == (int)Math.Sqrt(nums[i]))
                {
                    squareNums.Add(nums[i]);
                }
            }
            squareNums.Sort();
            squareNums.Reverse();
            Console.WriteLine(string.Join(" ",squareNums));
        }
    }
}
