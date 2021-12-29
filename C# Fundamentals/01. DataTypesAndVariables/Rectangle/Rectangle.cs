using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle
{
    class Rectangle
    {
        static void Main(string[] args)
        {
            decimal a = decimal.Parse(Console.ReadLine());
            decimal b = decimal.Parse(Console.ReadLine());
            
            decimal perimeter = (2 * a) + (2 * b);
            decimal area = a * b;
            decimal dSquare = (a * a) + (b * b);
            decimal d = (decimal)Math.Sqrt((double)dSquare);

            Console.WriteLine(perimeter);
            Console.WriteLine(area);
            Console.WriteLine(d);
        }
    }
}
