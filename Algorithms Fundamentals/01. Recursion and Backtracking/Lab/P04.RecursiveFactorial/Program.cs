using System;

namespace P04.RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalcFuct(n));
        }

        private static int CalcFuct(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            return n * CalcFuct(n - 1);
        }
    }
}
