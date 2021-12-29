using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Fibonacci
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var f0 = 1;
            var f1 = 1;

            for (int i = 1; i <= n-1; i++)
            {
                var sum = f0 + f1;
                f0 = f1;
                f1 = sum;
            }
            Console.WriteLine(f1);
        }
    }
}
