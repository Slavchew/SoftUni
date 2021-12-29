using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiply_Even_by_Odd_Digits
{
    class Program
    {
        // 08. Умножение на четна и нечетна сума

        // Умножение на четни и нечетни
        static double Multiply(double even, double odd)
        {
            return even * odd;
        }

        // Намира сума на четните числа
        static double EvenSum(int number)
        {
            double evenSum = 0;
            while (number > 0)
            {
                int lastDigit = number % 10;
                number /= 10;
                if (lastDigit % 2 == 0) evenSum += lastDigit;
            }
            return evenSum;
        }

        // Намира сума на нечетните числа
        static double OddSum(int number)
        {
            double oddSum = 0;
            while (number > 0)
            {
                int lastDigit = number % 10;
                number /= 10;
                if (lastDigit % 2 != 0) oddSum += lastDigit;
            }
            return oddSum;
        }

        //// Главен метод
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            Console.WriteLine(Multiply(EvenSum(number), OddSum(number)));
        }
    }
}
