using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_in_Range_1_100
{
    class Program
    {
        static void Main(string[] args)
        {
            //var n = int.Parse(Console.ReadLine());
            //while (n < 1 || n > 100)
            //{
            //    Console.WriteLine("Invalid number!");
            //    n = int.Parse(Console.ReadLine());
            //}
            //Console.WriteLine($"The number is: {n}");

            var n = -1;
            while (true)
            {

                try
                {
                    n = int.Parse(Console.ReadLine());
                    if (n >= 1 && n <= 100)
                    {
                        break;
                    }
                    Console.WriteLine("Invalid number!");
                }
                catch
                {
                    Console.WriteLine("This is not a number");
                }
            }
            Console.WriteLine($"The number is: {n}");

        }
    }
}
