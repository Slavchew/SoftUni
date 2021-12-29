using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Christmas_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            //var n = int.Parse(Console.ReadLine());
            //for (int row = 0; row <= n; row++)
            //{
            //    for (int i = 0; i < n-row; i++)
            //    {
            //        Console.Write(" ");
            //    }
            //    for (int i = 0; i < row; i++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.Write(" | ");
            //    for (int i = 0; i < row; i++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}


            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i <= n; i++)
            {
                var stars = new string('*',i);
                var spaces = new string(' ',n - i);
                Console.Write(spaces);
                Console.Write(stars);
                Console.Write(" | ");
                Console.Write(stars);
                Console.WriteLine(spaces);
            }
        }
    }
}
