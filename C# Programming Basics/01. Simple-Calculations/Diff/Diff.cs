using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diff
{
    class Diff
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведи две числа");
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var diff = a - b;
            Console.WriteLine("Сумата е = " + diff);
        }
    }
}
