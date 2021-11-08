using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Which_is_Number1_100
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведи число в интервал от 1 до 100 ");
            var n = int.Parse(Console.ReadLine());
            while (n < 1 || n >100 )
            {
                Console.WriteLine("Невалидно число");
                Console.WriteLine("Въведи число в интервал от 1 до 100 отново ");
                n = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Числото е " + n);
        }
    }
}
