using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest3Numbers
{
    class Largest3Numbers
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            var sortedNums = nums.OrderByDescending(x => x);
            var largest3Nums = sortedNums.Take(3);
            Console.WriteLine(string.Join(" ",largest3Nums));
        }
    }
}
