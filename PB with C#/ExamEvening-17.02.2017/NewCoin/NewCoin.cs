using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCoin
{
    class NewCoin
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            PrintTop(n);
            PrintBody(n);
            PrintBottom(n);
        }

        static void PrintTop(int n)
        {
            var leftNrightLines = n - 1;
            var dashes = 6;
            var spaces = 2 * n;

            // Print 1st Line
            Console.WriteLine("{0}{1}{2}",
                new string(' ',spaces),
                new string('\\',n),
                new string('/',n));

            spaces -= 2;

            for (int i = 0; i < n-1; i++)
            {
                Console.WriteLine("{0}{1}{2}{3}",
                    new string(' ', spaces),
                    new string('\\', leftNrightLines),
                    new string('-',dashes),
                    new string('/',leftNrightLines));

                leftNrightLines--;
                dashes += 6;
                spaces -= 2;
            }

        }

        static void PrintBody(int n)
        {
            PrintLineOverMid(n);

            //Print mid Line
            var slashes = 2 * n - 3;
            Console.WriteLine("|{0}{1} ESTD {2}{0}|",
                new string('~',n - 1),
                new string('/',slashes),
                new string('\\',slashes));

            PrintLineOverMid(n);
        }

        static void PrintBottom(int n)
        {
            var leftNrightLines = 1;
            var dashes = 6 * n - 6;
            var spaces = 2;


            for (int i = 0; i < n - 1; i++)
            {
                Console.WriteLine("{0}{1}{2}{3}",
                    new string(' ', spaces),
                    new string('/', leftNrightLines),
                    new string('-', dashes),
                    new string('\\', leftNrightLines));

                leftNrightLines++;
                dashes -= 6;
                spaces += 2;
            }

            // Print 1st Line
            Console.WriteLine("{0}{1}{2}",
                new string(' ', spaces),
                new string('/', n),
                new string('\\', n));
        }

        static void PrintLineOverMid(int n)
        {
            if (n % 2 == 0)
            {
                for (int i = 0; i < (n - 2) / 2; i++)
                {
                    Console.WriteLine("|{0}{1}{0}|",
                        new string('-', n - 1),
                        new string('#', 4 * n));
                }
            }
            else
            {
                for (int i = 0; i < (n - 3) / 2; i++)
                {
                    Console.WriteLine("|{0}{1}{0}|",
                        new string('-', n - 1),
                        new string('#', 4 * n));
                }
            }
        }
    }
}
