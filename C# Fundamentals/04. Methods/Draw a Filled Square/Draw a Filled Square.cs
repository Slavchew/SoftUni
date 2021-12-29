using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw_a_Filled_Square
{
    class Program
    {
        // 04. Рисуване на запълнен квадрат

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Dashes(n);
            for (int i = 0; i < n - 2; i++)
            {
                Body(n);
            }
            Dashes(n);
        }

        // Рисуване на тирета
        static void Dashes(int n)
        {
            var dashes = 2 * n;
            Console.WriteLine(new string('-',dashes));
        }

        // Рисуване на тялото
        static void Body(int n)
        {
            Console.Write("-");
            for (int i = 0; i < n - 1; i++)
            {
                Console.Write("\\/");
            }
            Console.WriteLine("-");
        }
    }
}
