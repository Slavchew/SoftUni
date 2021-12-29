using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Up_and_Down_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var sum1 = 0;
            for (int i = 0; i < n; i++)
            {
                var x = int.Parse(Console.ReadLine());
                sum1 = sum1 + x;
            }

            var sum2 = 0;
            for (int i = 0; i < n; i++)
            {
                var x = int.Parse(Console.ReadLine());
                sum2 = sum2 + x;
            }
            if (sum1 == sum2)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = {0} ", sum1);
            }
            else
            {
                var diff = Math.Abs(sum1 - sum2);
                Console.WriteLine("No");
                Console.WriteLine("Diff = {0} ", diff);
            }
        }
    }
}
