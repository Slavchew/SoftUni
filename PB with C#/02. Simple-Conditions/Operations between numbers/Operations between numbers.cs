using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations_between_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = double.Parse(Console.ReadLine());
            var b = double.Parse(Console.ReadLine());
            char symbol = char.Parse(Console.ReadLine());
            double sum = 0.0;
            if (symbol == '+')
            {
                sum = a + b;
                if (sum % 2 == 0)
                {
                    Console.WriteLine($"{a} + {b} = {sum} - even");
                }
                else
                    Console.WriteLine($"{a} + {b} = {sum} - odd");
            }
            else if (symbol == '-')
            {
                sum = a - b;
                if (sum % 2 == 0)
                {
                    Console.WriteLine($"{a} - {b} = {sum} - even");
                }
                else
                    Console.WriteLine($"{a} - {b} = {sum} - odd");
            }
            else if (symbol == '*')
            {
                sum = a * b;
                if (sum % 2 == 0)
                    Console.WriteLine($"{a} * {b} = {sum} - even");
                else
                    Console.WriteLine($"{a} * {b} = {sum} - odd");
            }
            else if (symbol == '/')
            {
                if (b == 0)
                {
                    Console.WriteLine($"Cannot divide {a} by zero");
                }
                else
                {
                    sum = a / b;
                    Console.WriteLine($"{a} / {b} = {sum:f2}");
                }
            }
            else if (symbol == '%')
            {
                if (b == 0)
                {
                    Console.WriteLine($"Cannot divide {a} by zero");
                }
                else
                {
                    sum = a % b;
                    Console.WriteLine($"{a} % {b} = {sum}");
                }
            }

        }
    }
}
