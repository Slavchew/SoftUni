using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pass_Length
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Въведи парол,която е над 8 символа:");
            var pass = Console.ReadLine();
            var a = false;
            while (pass.Length > 8)
            {
                a = true;
                break;
            }
            if (a == true)
            {
                Console.WriteLine("Добре дошли");
            }
            else
            {
                Console.WriteLine("Грешна парола");
            }
        }
    }
}
