using System;

namespace P03.GeneratingVectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var arr = new int[n];

            GenerateVectors(arr, 0);
        }

        private static void GenerateVectors(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join("", arr));
                return;
            }

            for (int number = 0; number <= 1; number++)
            {
                arr[index] = number;
                GenerateVectors(arr, index + 1);
            }
        }
    }
}
