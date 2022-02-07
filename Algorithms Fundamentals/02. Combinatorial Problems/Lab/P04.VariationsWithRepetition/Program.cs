using System;

namespace P04.VariationsWithRepetition
{
    internal class Program
    {
        private static string[] elements;
        private static int k;
        private static string[] variations;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());

            variations = new string[k];

            Variations(0);
        }

        private static void Variations(int variationsIndex)
        {
            if (variationsIndex >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                variations[variationsIndex] = elements[i];
                Variations(variationsIndex + 1);
            }
        }
    }
}
