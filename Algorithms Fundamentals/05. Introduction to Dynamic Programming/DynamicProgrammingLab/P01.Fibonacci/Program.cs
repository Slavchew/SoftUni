using System;
using System.Collections.Generic;

namespace P01.Fibonacci
{
    internal class Program
    {
        private static Dictionary<int, long> cache;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            cache = new Dictionary<int, long>();

            Console.WriteLine(GetFibonacci(n));
        }

        private static long GetFibonacci(int n)
        {
            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            if (n <= 2)
            {
                return 1;
            }

            var result =  GetFibonacci(n - 1) + GetFibonacci(n - 2);
            cache[n] = result;

            return result;
        }
    }
}
