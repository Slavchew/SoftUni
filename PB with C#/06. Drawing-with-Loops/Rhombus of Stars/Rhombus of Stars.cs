using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhombus_of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            // Draw Top Part
            for (int row = 1; row <= n; row++)
            {
                for (int col = 0; col < n-row; col++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                for (int col = 0; col < row-1; col++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine();
            }
            // Draw Bottom Part
            var stars = n-1;
            for (int row = 0; row < n-1; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                for (int col = 0; col < stars-1; col++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine();
                stars--;
            }
        }
    }
}
