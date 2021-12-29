using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeToN
{
    class PrimeToN
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            bool[] primes = new bool[n + 1];
            for (int i = 2; i <= n; i++)
            {
                primes[i] = true;
            }

            for (int num = 2; num <= n; num++)
            {
                if (primes[num])
                {
                    Console.WriteLine(num);
                    var p = num * 2;
                    while (p <= n)
                    {
                        primes[p] = false;
                        p += num;
                    }
                }
            }
        }
    }
}
