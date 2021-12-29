using System;
using System.Linq;

namespace Raindrops
{
    class Raindrops
    {
        static void Main(string[] args)
        {
            uint n = uint.Parse(Console.ReadLine());
            double density = double.Parse(Console.ReadLine());

            double rainCoeffSum = 0.0;

            for (int i = 0; i < n; i++)
            {
                uint[] input = Console.ReadLine().Split(' ').Select(uint.Parse).ToArray();
                uint raindropsCount = input[0];
                uint squareMeters = input[1];
                double rainCoefficient = (double)raindropsCount / squareMeters;
                rainCoeffSum += rainCoefficient;
            }

            if (density <= 0)
            {
                Console.WriteLine($"{rainCoeffSum:f3}");
            }
            else
            {
                var result = rainCoeffSum / density;

                Console.WriteLine($"{result:f3}");
            }
        }
    }
}
