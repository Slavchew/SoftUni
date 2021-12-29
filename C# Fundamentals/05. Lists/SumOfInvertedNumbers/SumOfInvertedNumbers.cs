using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfInvertedNumbers
{
    class SumOfInvertedNumbers
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ');
            for (int i = 0; i < nums.Count(); i++)
            {
                nums[i] = String.Join("", nums[i].Reverse());
            }
            Console.WriteLine(nums.Select(int.Parse).Sum());
        }
    }
}
