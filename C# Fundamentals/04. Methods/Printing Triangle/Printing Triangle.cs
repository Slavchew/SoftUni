using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printing_Triangle
{
    class Program
    {
        // 03. Принтиране на триъгълник

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            for (int i = 1; i < n; i++)
            {
                PrintNums(1 , i);
            }
            for (int i = n; i >= 1; i--)
            {
                PrintNums(1, i);
            }
        }
        
        // Ред от триъгълника
        static void PrintNums(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
