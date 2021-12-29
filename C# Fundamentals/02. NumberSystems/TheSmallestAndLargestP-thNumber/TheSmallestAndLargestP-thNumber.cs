using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSmallestAndLargestP_thNumber
{
/* Задача 2.	
   Запишете най-малкото и най-голямото двуцифрено число в P-ична бройна система, 
   запишете в същата бройна система на колко е равна тяхната разлика.
*/
    class TheSmallestAndLargestP_thNumber
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var max = n * n - 1;

            Console.WriteLine("MIN = {0}",n);
            Console.WriteLine("MAX = {0}", max);
            Console.WriteLine("DIFF = {0}",max - n);
        }
    }
}
