using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Power
{
    class Program
    {
        // 06. Степен на число

        //// Гравен метод
        static void Main(string[] args)
        {
            var number = double.Parse(Console.ReadLine());
            var power = double.Parse(Console.ReadLine());
            Console.WriteLine(CalculatePower(number, power));
        }

        // Намиране на число на n-та степен
        static double CalculatePower(double number, double power)
        {
            double result = Math.Pow(number, power);
            return result;
        }
    }
}
