using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class test
    {
        static void Main(string[] args)
        {
            var speed = decimal.Parse(Console.ReadLine());
            if (speed < 0)
            {
                Console.WriteLine("Некоректна скорост!");
            }
            else if (speed <= 50)
            {
                Console.WriteLine("Ниска скорост!");
            }
            else if (speed > 50 && speed <= 80)
            {
                Console.WriteLine("Средна скорост!");
            }
            else
            {
                Console.WriteLine("Висока скорост!");
            }
        }
    }
}
