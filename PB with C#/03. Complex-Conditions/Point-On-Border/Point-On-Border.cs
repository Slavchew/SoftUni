using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_On_Border
{
    class Program
    {
        static void Main(string[] args)
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());
            var x = double.Parse(Console.ReadLine());
            var y = double.Parse(Console.ReadLine());

            var topSide = (x == x1) && (y >= y1) && (y <= y2);
            var bottomSide = (x == x2) && (y >= y1) && (y <= y2);
            var rightSide = (y == y1) && (x >= x1) && (x <= x2);
            var leftSide = (y == y2) && (x >= x1) && (x <= x2);

            if (topSide || bottomSide || rightSide || leftSide)
            {
                Console.WriteLine("Border");
            }
            else
            {
                Console.WriteLine("Inside / Outside");
            }
        }
    }
}
