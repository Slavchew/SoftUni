using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreaterNumber
{
    class GreaterNumber
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Въведете две числа");
            var num1 = int.Parse(Console.ReadLine());
            var num2 = int.Parse(Console.ReadLine());
            if (num1>num2)
            {
                Console.WriteLine("Greater Number is:" + num1);
            }
            else
                Console.WriteLine("Greater Number is:" + num2);

        }
    }
}
