using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_N_Square_of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                if (i == 0 || i == n-1)
                {
                    Console.Write(new string('*', n));
                }
                else
                {
                    Console.Write("*");
                    for (int j = 0; j < n-2; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
