using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveNumber
{
    class RemoveNumber
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int num = nums[nums.Count - 1];
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums.Contains(num))
                {
                    nums.Remove(num);
                    i--;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
