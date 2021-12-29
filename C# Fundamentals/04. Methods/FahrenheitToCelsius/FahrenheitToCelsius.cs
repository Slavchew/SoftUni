using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrenheitToCelsius
{
    class FahrenheitToCelsius
    {
        static void Main(string[] args)
        {
            var fahrenheit = double.Parse(Console.ReadLine());
            var celsius = FahrenheitToCelsiusMethod(fahrenheit);
            Console.WriteLine($"{celsius:f2}");
        }

        static double FahrenheitToCelsiusMethod(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }
}
