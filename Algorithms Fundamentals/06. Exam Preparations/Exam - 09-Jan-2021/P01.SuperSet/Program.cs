using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.SuperSet
{
    internal class Program
    {
        private static int[] numbers;
        private static int k;
        private static int[] combinations;

        static void Main(string[] args)
        {
            numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            k = numbers.Length;

            for (int i = 0; i <= k; i++)
            {
                combinations = new int[i];

                GetSuperSet(0, 0);
            }
        }

        private static void GetSuperSet(int combIdx, int elementsStartIndex)
        {
            if (combIdx >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementsStartIndex; i < numbers.Length; i++)
            {
                combinations[combIdx] = numbers[i];
                GetSuperSet(combIdx + 1, i + 1);
            }
        }
    }
}
