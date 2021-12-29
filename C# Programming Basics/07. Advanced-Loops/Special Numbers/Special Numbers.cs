using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var ones = 0;
            var tens = 0;
            var hundreds = 0;
            var thousands = 0;

            for (int i = 1111; i <= 9999; i++)
            {
                ones = i % 10;
                tens = (i / 10) % 10;
                hundreds = (i / 100) % 10;
                thousands = i / 1000;

                if (ones == 0 || tens == 0 || hundreds == 0 || thousands == 0)
                {
                    continue;
                }

                if (n % ones == 0 &&
                    n % tens == 0 &&
                    n % hundreds == 0 && 
                    n % thousands == 0)
                {
                    Console.Write($"{i} ");
                }
            }
            Console.WriteLine();
        }
    }
}
