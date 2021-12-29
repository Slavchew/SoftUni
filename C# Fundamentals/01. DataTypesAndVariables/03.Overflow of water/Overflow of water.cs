using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Overflow_of_water
{
    class Overflow_of_water
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            short capacity = (short)255;
            short capacityLeft = capacity;
            for (int i = 0; i < n; i++)
            {
                short water = short.Parse(Console.ReadLine());

                if (capacityLeft - water >= 0)
                {
                    capacityLeft -= water;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            short filled = (short)(capacity - capacityLeft);
            Console.WriteLine(filled);
        }
    }
}
