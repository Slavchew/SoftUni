using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers_from_1_to_100
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 1; i <= 100; i++)
            //{
            //    Console.WriteLine(i);
            //}
            int x = int.Parse(Console.ReadLine());
            if (Enumerable.Range(1, 100).Contains(x))
                Console.WriteLine("True");
            else
                Console.WriteLine("False");

        }
    }
}
