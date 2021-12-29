using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.ComparisonOfRealNumbers
{
    class ComparisonOfRealNumbers
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double greater = Math.Max(a, b);
            double min = Math.Min(a, b);
            double diff = greater - min;
            double eps = 0.000001;
            if (diff < eps)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }

        }
    }
}
