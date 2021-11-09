using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celsium_to_Fahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведете градуси в Целзий");
            var celsium = double.Parse(Console.ReadLine());
            var Fahrenheit = (celsium * 1.8) + 32;
            Console.WriteLine(Math.Round(Fahrenheit,2) + "°F");
        }
    }
}
