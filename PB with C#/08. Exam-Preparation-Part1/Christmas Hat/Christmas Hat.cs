using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Christmas_Hat
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var dots = 2 * n - 1;
            var midDash = 1;
            var length = 4 * n + 1;


            Console.WriteLine("{0}/|\\{0}",
                new string('.',dots));
            Console.WriteLine("{0}\\|/{0}",
                new string('.', dots));

            Console.WriteLine("{0}***{0}",
               new string('.', dots));

            dots--;

            for (int i = 0; i < 2 * n - 1; i++)
            {
                Console.WriteLine("{0}*{1}*{1}*{0}",
                    new string('.',dots),
                    new string('-',midDash));

                dots--;
                midDash++;
            }

            Console.WriteLine("{0}",
                new string('*',length));

            for (int i = 0; i < length; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write("*");
                }
                else
                    Console.Write(".");
            }
            Console.WriteLine();

            Console.WriteLine("{0}",
                new string('*', length));
        }
    }
}
