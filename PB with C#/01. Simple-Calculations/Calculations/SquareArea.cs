using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    class SquareArea
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете страната на квадрата: a = ");
            var a = double.Parse(Console.ReadLine());
            Console.WriteLine("Лицето е = " + (a * a));
        }
    }
}
