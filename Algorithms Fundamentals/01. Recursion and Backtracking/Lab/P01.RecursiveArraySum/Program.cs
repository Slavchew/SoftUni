using System;
using System.Linq;

namespace P01.RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(Sum(arr, 0));
        }

        private static int Sum(int[] arr, int index)
        {
            if (index >= arr.Length - 1)
            {
                return arr[index];
            }

            return arr[index] + Sum(arr, index + 1);
        }
    }
}
