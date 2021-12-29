using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyBigNums
{
    class MultiplyBigNums
    {
        static void Main(string[] args)
        {
            var number1 = Console.ReadLine();
            var number2 = int.Parse(Console.ReadLine());

            var result = new StringBuilder();
            var carry = 0;

            for (int i = number1.Length - 1; i >= 0; i--)
            {
                var tempRes = int.Parse(number1[i].ToString()) * number2 + carry;
                result.Insert(0, tempRes % 10);
                carry = tempRes / 10;
            }

            if (carry > 0) result.Insert(0, carry);

            if (result.ToString().TrimStart('0').Length == 0)
                Console.WriteLine("0");
            else
                Console.WriteLine(result.ToString().TrimStart('0'));
        }
    }
}
