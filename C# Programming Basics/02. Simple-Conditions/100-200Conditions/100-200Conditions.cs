using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100_200Conditions
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            if (n < 100)
            {
                Console.WriteLine("Less than 100");
            }
            else if (n == 100)
            {
                Console.WriteLine("It's equal to 100");
            }
            else if (n > 100 && n <= 200)
            {
                Console.WriteLine("Between 100 and 200");
            }
            else
                Console.WriteLine("Greater than 200");
        }
    }
}
