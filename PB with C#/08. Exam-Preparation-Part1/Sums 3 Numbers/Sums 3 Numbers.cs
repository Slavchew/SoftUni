using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sums_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var num1 = int.Parse(Console.ReadLine());
            var num2 = int.Parse(Console.ReadLine());
            var num3 = int.Parse(Console.ReadLine());

            var max = Math.Max(Math.Max(num1,num2),num3);
            var min = Math.Min(Math.Min(num1, num2), num3);
            var sum = num1 + num2 + num3;
            var mid = sum - max - min;

            if (min + mid == max)
                Console.WriteLine($"{min} + {mid} = {max}");
            else
                Console.WriteLine("No");

        }
    }
}
