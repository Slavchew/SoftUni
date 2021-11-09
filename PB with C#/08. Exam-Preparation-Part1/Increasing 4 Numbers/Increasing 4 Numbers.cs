using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Increasing_4_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var count = true;

            for (int num1 = a; num1 <= b; num1++)
            {
                for (int num2 = num1 + 1; num2 <= b; num2++)
                {
                    for (int num3 = num2 + 1; num3 <= b; num3++)
                    {
                        for (int num4 = num3 + 1; num4 <= b; num4++)
                        {
                            Console.WriteLine($"{num1} {num2} {num3} {num4}");
                            count = false;
                        }
                    }
                }
            }
            if (count)
            {
                Console.WriteLine("No");
            }
        }
    }
}
