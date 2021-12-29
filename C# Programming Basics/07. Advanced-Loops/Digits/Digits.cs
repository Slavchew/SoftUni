using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits
{
    class Digits
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());

            var ones = num % 10;
            var tens = (num / 10) % 10;
            var hundreds = (num / 100) % 10;

            var n = hundreds + tens;
            var m = hundreds + ones;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m ; j++)
                {
                    if (num % 5 == 0)
                    {
                        num -= hundreds;
                    }
                    else if (num % 3 == 0)
                    {
                        num -= tens;
                    }
                    else
                    {
                        num += ones;
                    }

                    Console.Write($"{num} ");
                }
                Console.WriteLine();
            }
        }
    }
}
