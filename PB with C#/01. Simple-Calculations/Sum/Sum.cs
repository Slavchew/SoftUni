using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum
{
    class Sum
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведи две числа");
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var sum = a + b;
            Console.WriteLine("Сумата е = " + sum);
        }
    }
}
