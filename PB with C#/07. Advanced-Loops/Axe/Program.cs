using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axe
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var width = 5 * n;
            var leftDashes = 3 * n;
            var midDashes = 0;
            var rightDashes = width - leftDashes - midDashes - 2;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}*{1}*{2}",
                    new string ('-',leftDashes),
                    new string ('-',midDashes),
                    new string ('-',rightDashes));

                midDashes++;
                rightDashes--;
            }

            midDashes--;
            rightDashes++;

            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}*{1}*{2}",
                    new string('*',leftDashes),
                    new string('-',midDashes),
                    new string('-',rightDashes));
            }


            for (int i = 0; i < n / 2 - 1; i++)
            {
                Console.WriteLine("{0}*{1}*{2}",
                     new string('-', leftDashes),
                    new string('-', midDashes),
                    new string('-', rightDashes));

                leftDashes--;
                midDashes += 2;
                rightDashes--;
            }

            Console.WriteLine("{0}*{1}*{2}",
                     new string('-', leftDashes),
                    new string('*', midDashes),
                    new string('-', rightDashes));
        }
    }
}
