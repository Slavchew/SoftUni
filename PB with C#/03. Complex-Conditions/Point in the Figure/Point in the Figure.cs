using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_in_the_Figure
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            var outside1 = (x < 0) || (x > 3 * h) || (y < 0) || (y > h);
            var outside2 = (x < h) || (x > 2 * h) || (y < h) || (y > 4 * h);

            var inside1 = (x > 0) && (x < 3 * h) && (y > 0) && (y < h);
            var inside2 = (x > h) && (x < 2 * h) && (y > h) && (y < 4 * h);
            var common = (x > h) && (x < 2 * h) && (y == h);

            if (outside1 && outside2)
                Console.WriteLine("outside");
            else if (inside1 || inside2 || common)
                Console.WriteLine("inside");
            else
                Console.WriteLine("border");
        }
    }
}
