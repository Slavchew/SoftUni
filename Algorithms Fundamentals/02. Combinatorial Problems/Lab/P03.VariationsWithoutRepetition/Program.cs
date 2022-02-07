using System;

namespace P03.VariationsWithoutRepetition
{
    internal class Program
    {
        private static string[] elements;
        private static int k;

        private static string[] variations;
        private static bool[] used;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());

            variations = new string[k];
            used = new bool[elements.Length];

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
                if (!used[i])
                {
                    used[i] = true;
                    variations[variationsIndex] = elements[i];
                    Variations(variationsIndex + 1);
                    used[i] = false;
                }
            }
        }
    }
}
