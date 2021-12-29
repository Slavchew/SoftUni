using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly
{
    class Butterfly
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            if (n >= 3 && n <= 1000)
            {
                var leftRight = n - 2;
                Console.WriteLine("{0}\\ /{0}",new string('*', leftRight));
                for (int i = 0; i < (n - 2) / 2; i++)
                {
                    Console.WriteLine("{0}\\ /{0}",
                        new string('-', leftRight));
                    Console.WriteLine("{0}\\ /{0}",
                        new string('*', leftRight));
                }
                Console.Write(new string(' ', leftRight + 1));
                Console.Write("@");
                Console.WriteLine(new string(' ', leftRight + 1));
                for (int i = 0; i < (n - 2) / 2; i++)
                {
                    Console.WriteLine("{0}/ \\{0}",
                        new string('*', leftRight));
                    Console.WriteLine("{0}/ \\{0}",
                        new string('-', leftRight));
                }
                Console.WriteLine("{0}/ \\{0}", new string('*', leftRight));
            }
        }
    }
}
