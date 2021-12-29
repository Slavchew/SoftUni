using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invalid_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var Range = (num >= 100 && num <= 200 || num == 0);
            if (!Range)
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}
