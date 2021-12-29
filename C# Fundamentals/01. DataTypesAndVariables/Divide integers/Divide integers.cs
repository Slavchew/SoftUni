using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divide_integers
{
    class Divide_integers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int remainder = 0;
            int sumOfRemainder = 0;

            for (int i = 0; i < n; i++)
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());

                remainder = a % b;
                sumOfRemainder += remainder;
            }

            Console.WriteLine(sumOfRemainder);
        }
    }
}
