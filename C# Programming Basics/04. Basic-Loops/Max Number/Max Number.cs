using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете брой числа n = ");
            var n = int.Parse(Console.ReadLine());
            var max = int.MinValue;
            for (int i = 1; i <= n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                if (num > max)
                {
                    max = num;
                }
            }
            Console.WriteLine("Най-голямото число е: " + max);
        }
    }
}
