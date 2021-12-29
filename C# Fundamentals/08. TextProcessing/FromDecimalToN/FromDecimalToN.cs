using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FromDecimalToN
{
    class FromDecimalToN
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();
            var base1 = nums[0];
            BigInteger num = nums[1];
            var result = new StringBuilder();
            while (num > 0)
            {
                var digit = num % base1;
                num /= base1;

                result.Insert(0, digit);
            }
            Console.WriteLine(result);
        }
    }
}
