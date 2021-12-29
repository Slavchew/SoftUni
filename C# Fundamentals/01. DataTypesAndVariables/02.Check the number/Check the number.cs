using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Check_the_number
{
    class Check_the_number
    {
        static void Main(string[] args)
        {
            var num = double.Parse(Console.ReadLine());

            if (num == Math.Ceiling(num))
            {
                Console.WriteLine("integer");
            }
            else
            {
                Console.WriteLine("floating-point");
            }
        }
    }
}
