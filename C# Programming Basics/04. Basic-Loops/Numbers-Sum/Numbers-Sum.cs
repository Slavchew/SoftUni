using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете брой числа n = ");
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine("Въведете {0} числа едно след друго:", n);
            var sum = 0;
            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                sum = sum + num;
            }
            Console.WriteLine("Сумата е: " + sum);
        }
    }
}
