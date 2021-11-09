using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow
{
    class Arrow
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var dots = n / 2;

            Console.WriteLine("{0}{1}{0}",
                new string('.',dots),
                new string('#',n));

            for (int i = 0; i < n - 2; i++)
            {
                Console.WriteLine("{0}#{1}#{0}",
                    new string('.', dots),
                    new string('.', n - 2));
            }

            Console.WriteLine("{0}{1}{0}",
                new string('#',dots + 1),
                new string('.',n - 2));

            dots = 1;
            var interDots = 2 * n - 5;

            for (int i = 0; i < n - 2; i++)
            {
                Console.WriteLine("{0}#{1}#{0}",
                    new string('.',dots),
                    new string('.', interDots));

                dots++;
                interDots -= 2;
            }

            Console.WriteLine("{0}#{0}",
                new string('.',n - 1));
        }
    }
}
