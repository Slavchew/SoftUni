using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Triangle_Area
{
    class Program
    {
        // 05. Лице на триъгълник

        //// Главен Метод
        static void Main(string[] args)
        {
            var a = double.Parse(Console.ReadLine());
            var h = double.Parse(Console.ReadLine());
            var area = TriangleArea(a, h);
            Console.WriteLine(area);
        }

        // Намеране на лице на триъгълник
        static double TriangleArea(double length, double height)
        {
            return (length * height) / 2;
        }
    }
}
