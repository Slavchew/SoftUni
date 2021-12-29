using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BigFactorial
{
    class BigFactorial
    {
        static void Main(string[] args)
        {
            var n = BigInteger.Parse(Console.ReadLine());
            BigInteger num = 1;

            for (int i = 2; i <= n; i++)
            {
                num = num * i;
            }
            Console.WriteLine(num);
        }

    }
}
