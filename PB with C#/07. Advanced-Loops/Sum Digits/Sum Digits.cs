using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            n = Math.Abs(n);
            var sum = 0;
            var typeNumber = 0;
            while (n > 0)
            {
                var digit = n % 10;
                sum += digit;
                typeNumber += 1;
                n /= 10;

            }
            //if (typeNumber == 1)
            //    Console.WriteLine("Едноцифрено");
            //else if (typeNumber == 2)
            //    Console.WriteLine("Двуцифрено");
            //TODO
            Console.WriteLine($"Броя на цифрите в числото е:{typeNumber}");
            Console.WriteLine($"Сумата от цифрите в числото е:{sum}");
        }
    }
}
