using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOFBigNums
{
    class SumOFBigNums
    {
        static void Main(string[] args)
        {
            var number1 = Console.ReadLine();
            var number2 = Console.ReadLine();

            var maxLen = Math.Max(number1.Length, number2.Length);
            number1 = new string('0', maxLen - number1.Length) + number1;
            number2 = new string('0', maxLen - number2.Length) + number2;

            var result = new StringBuilder();
            var carry = 0;

            for (int i = maxLen - 1; i >= 0; i--)
            {
                var tempRes = int.Parse(number1[i].ToString()) + int.Parse(number2[i].ToString()) + carry;
                result.Insert(0, tempRes % 10);
                carry = tempRes / 10;
            }

            if (carry > 0) result.Insert(0, carry);

            Console.WriteLine(result.ToString().TrimStart('0'));

        }
    }
}
