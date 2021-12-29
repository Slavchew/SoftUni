using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOf2EqualNums
{
    class SumOf2EqualNums
    {
        static void Main(string[] args)
        {
            List<double> nums = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i - 1] == nums[i])
                {
                    var num = nums[i - 1];
                    nums.RemoveRange(i - 1, 2);
                    nums.Insert(i - 1, num * 2);
                    i = 0;
                }
            }
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
