using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            (double, double) point = ChooseNearnest(x1, y1, x2, y2);

            Console.WriteLine(point);
        }

        private static (double, double) ChooseNearnest(double x1, double y1, double x2, double y2)
        {
            double c1 = Math.Pow(x1, 2) + Math.Pow(y1, 2);
            c1 = Math.Sqrt(c1);

            double c2 = Math.Pow(x2, 2) + Math.Pow(y2, 2);
            c2 = Math.Sqrt(c2);

            if (c1 > c2)
            {
                return (x2, y2);
            }

            return (x1, y1);
        }
    }
}
