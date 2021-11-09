using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstSpeed = int.Parse(Console.ReadLine());
            var firstTime = int.Parse(Console.ReadLine()); 
            var secondTime = int.Parse(Console.ReadLine());
            var thirdTime = int.Parse(Console.ReadLine());

            var firstDis = firstSpeed * (firstTime / 60.00);
            var secondSpeed = firstSpeed * 1.10;
            var secondDis = secondSpeed * (secondTime / 60.00);
            var thirdSpeed = secondSpeed * 0.95;
            var thirdDis = thirdSpeed * (thirdTime / 60.00);

            var wholeDis = firstDis + secondDis + thirdDis;

            Console.WriteLine("{0:f2}",wholeDis);

        }
    }
}
