using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Garage
    {
        // 05. Гараж
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var length = 2 * n + 2;
            var height = n + 2;
            var bodyHeight = n - 4;

            PrintTop(length);
            PrintBody(n, length, bodyHeight);
            PrintBottom(n, length);

        }

        // Рисуване на горната част
        static void PrintTop(int length)
        {
            Console.WriteLine(new string('|', length));
            Console.WriteLine(new string('+', length));
        }

        // Рисуване на тялото
        static void PrintBody(int n, int length, int bodyHeight)
        {
            Console.WriteLine("{0}GARAGE{0}",
                new string('|', n - 2));

            for (int i = 0; i < bodyHeight; i++)
            {
                Console.WriteLine(new string('|', length));
            }
        }

        // Рисуване на долната част
        static void PrintBottom(int n, int length)
        {
            if (n == 3)
            {
                for (int i = 0; i < 1; i++)
                {
                    Console.WriteLine("|{0}|{1}|{2}|",
                        new string('/', (length - 8) / 2),
                        new string(' ', 4),
                        new string('\\', (length - 8) / 2));
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("|{0}|{1}|{2}|",
                        new string('/', (length - 8) / 2),
                        new string(' ', 4),
                        new string('\\', (length - 8) / 2));
                }
            }

            Console.WriteLine("{0}{1}",
                new string(' ', (length - 5) / 2),
                new string('/', 5));
        }
    }
}
