using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trapezoid_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведете голямата основа на трапеца");
            var a = double.Parse(Console.ReadLine());
            Console.WriteLine("Въведете малката основа на трапеца");
            var b = double.Parse(Console.ReadLine());
            Console.WriteLine("Въведете височината на трапеца");
            var h = double.Parse(Console.ReadLine());
            var area = (a + b) * h / 2;
            Console.WriteLine("Лицето на трапеца е:" + Math.Round(area,2));
        }
    }
}
