using System;

namespace P02.NestedLoops
{
    internal class Program
    {
        private static int[] combinations;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            combinations = new int[n];

            GenerateCombinations(0);
        }

        private static void GenerateCombinations(int index)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = 1; i <= combinations.Length; i++)
            {
                combinations[index] = i;
                GenerateCombinations(index + 1);
            }
        }
    }
}
