using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddFilter
{
    class OddFilter
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var result = nums.Where(n => n % 2 == 0).ToArray();
            var avg = result.Average();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] <= avg)
                {
                    result[i]--;
                }
                else
                {
                    result[i]++;
                }
            }
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
