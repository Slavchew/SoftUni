using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decimal_to_hexadecimal_and_binary
{
    class Decimal_to_hexadecimal_and_binary
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            var num2Bin = Convert.ToString(num, 2);
            var num2Hex = Convert.ToString(num, 16).ToUpper();

            Console.WriteLine(num2Hex);
            Console.WriteLine(num2Bin);
        }
    }
}
