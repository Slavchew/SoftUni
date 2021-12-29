using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFromNbaseToDecimalBase
{
    class ConvertFromNbaseToDecimalBase
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToList();
            var oldBase = int.Parse(input[0]);
            var number = input[1];
            BigInteger baseTen = 0;

            for (int i = 0; i < number.Length; i++)
            {
                baseTen += Convert.ToInt32(new String(number[i], 1)) * BigInteger.Pow(oldBase, number.Length - 1 - i);
            }

            Console.WriteLine(baseTen);
        }
    }
}
