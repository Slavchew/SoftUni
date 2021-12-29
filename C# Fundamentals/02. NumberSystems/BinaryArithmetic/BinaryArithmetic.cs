using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryArithmetic
{
/* Задача 5. Двоична аритметика
   Преобразувайте числата в двоична бройна система и извършете действията в двоича бройна система. 
   След това преобразувайте резултата в десетична бройна система. 
   12+15= 
   9+15= 
   25-10= 
   45-17= 
   13*5= 
   17*3= 
   36/4= 
   81/9=    
*/
    class BinaryArithmetic
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            char sign = char.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            var sum = 0.0;
            if (sign == '+')
            {
                sum = a + b;
            }
            else if (sign == '-')
            {
                sum = a - b;
            }
            else if (sign == '*')
            {
                sum = a * b;
            }
            else if (sign == '/')
            {
                sum = a / b;
            }

            String s = $"{sum}";
            int fromBase = 10;
            int toBase = 2;

            String result = Convert.ToString(Convert.ToInt32(s, fromBase), toBase);
            String result2 = Convert.ToString(Convert.ToInt32(result, toBase), fromBase);
            Console.WriteLine(result2);

        }
    }
}
