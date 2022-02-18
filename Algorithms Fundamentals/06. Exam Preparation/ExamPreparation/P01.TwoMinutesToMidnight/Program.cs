using System;
using System.Collections.Generic;

namespace P01.TwoMinutesToMidnight
{
    internal class Program
    {
        private static Dictionary<string, long> cache;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());
            cache = new Dictionary<string, long>();

            var ways = GetBinom(n, k);
            Console.WriteLine(ways);
        }

        private static long GetBinom(int n, int k)
        {
            var id = $"{n} {k}";

            if (cache.ContainsKey(id))
            {
                return cache[id];
            }

            if (k == 0 || k == n)
            {
                return 1;
            }

            var result = GetBinom(n - 1, k) + GetBinom(n - 1, k - 1);
            cache[id] = result;
            return result;
        }
    }
}
