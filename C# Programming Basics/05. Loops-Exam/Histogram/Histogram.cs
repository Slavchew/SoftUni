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

            var p1Num = 0.0;
            var p2Num = 0.0;
            var p3Num = 0.0;
            var p4Num = 0.0;
            var p5Num = 0.0;


            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                if (num < 200)
                    p1Num ++;
                else if (num >= 200 && num <= 399)
                    p2Num ++;
                else if (num >= 400 && num <= 599)
                    p3Num ++;
                else if (num >= 600 && num <= 799)
                    p4Num ++;
                else if (num >= 800)
                    p5Num ++;
            }
            var p1 = p1Num / n * 100;
            var p2 = p2Num / n * 100;
            var p3 = p3Num / n * 100;
            var p4 = p4Num / n * 100;
            var p5 = p5Num / n * 100;

            Console.WriteLine("{0:f2}%", p1);
            Console.WriteLine("{0:f2}%", p2);
            Console.WriteLine("{0:f2}%", p3);
            Console.WriteLine("{0:f2}%", p4);
            Console.WriteLine("{0:f2}%", p5);

        }
    }
}
