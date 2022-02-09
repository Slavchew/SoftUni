using System;
using System.Linq;

namespace P01.ReverseArray
{
    internal class Program
    {
        private static int[] array;
        static void Main(string[] args)
        {
            array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Reverse(0, array.Length - 1);
            Console.WriteLine(string.Join(" ", array));
        }

        private static void Reverse(int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            Swap(start, end);
            Reverse(start + 1, end - 1);
        }

        private static void Swap(int start, int end)
        {
            var temp = array[start];
            array[start] = array[end];
            array[end] = temp;
        }
    }
}
