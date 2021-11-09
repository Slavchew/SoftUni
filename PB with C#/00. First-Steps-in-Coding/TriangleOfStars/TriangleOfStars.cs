using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleOfStars
{
    class TriangleOfStars
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            //var n = int.Parse(Console.ReadLine());
            //var stars = 1;
            //for (int i = 0; i < n; i++)
            //{
            //    Console.Write(new string('*', stars));
            //    Console.WriteLine();
            //    stars++;
            //}
        }
    }
}
