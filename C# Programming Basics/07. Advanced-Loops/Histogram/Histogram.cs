using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram
{
    class Histogram
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var p1 = 0.00;
            var p2 = 0.00;
            var p3 = 0.00;
            var p4 = 0.00;
            var p5 = 0.00;
            for (int i = 0; i < n; i++)
            {
                var x = int.Parse(Console.ReadLine());
                if (x < 200)
                {
                    p1 += 1;
                }
                else if (x >= 200 && x <= 399)
                {
                    p2 += 1;
                }
                else if (x >= 400 && x <= 599)
                {
                    p3 += 1;
                }
                else if (x >= 600 && x <= 799)
                {
                    p4 += 1;
                }
                else
                {
                    p5 += 1;
                }
            }
            p1 = (p1 / n) * 100;
            p2 = (p2 / n) * 100;
            p3 = (p3 / n) * 100;
            p4 = (p4 / n) * 100;
            p5 = (p5 / n) * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");
        }
    }
}
