using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division_without_remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var p1 = 0.00;
            var p2 = 0.00;
            var p3 = 0.00;
            for (int i = 0; i < n; i++)
            {
                var x = int.Parse(Console.ReadLine());
                if (x >= 1 && x <= 1000)
                {
                    if (x % 2 == 0)
                    {
                        p1 += 1;
                    }
                    if (x % 3 == 0)
                    {
                        p2 += 1;
                    }
                    if (x % 4 == 0)
                    {
                        p3 += 1;
                    }
                }
            }
            p1 = (p1 / n) * 100;
            p2 = (p2 / n) * 100;
            p3 = (p3 / n) * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
        }
    }
}
