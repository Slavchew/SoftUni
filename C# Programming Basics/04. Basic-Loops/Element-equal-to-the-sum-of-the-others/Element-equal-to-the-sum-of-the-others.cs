using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element_equal_to_the_sum_of_the_others
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var max = int.MinValue;
            var sum = 0.0;
            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                if (num > max)
                {
                    max = num;
                }
                sum = sum + num;
            }
            if ((sum / 2) == max)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {max}");
            }
            else
            {
                var diff1 = sum - max;
                var diff2 = Math.Abs(max - diff1);
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff2}");
            }

        }
    }
}
