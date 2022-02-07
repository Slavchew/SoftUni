using System;

namespace P01.PermutationsWithoutRepetitions
{
    internal class Program
    {
        private static string[] elements;
        private static string[] permutation;
        private static bool[] used;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            permutation = new string[elements.Length];
            used = new bool[elements.Length];

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", permutation));
                return;
            }

            for (int elmIdx = 0; elmIdx < elements.Length; elmIdx++)
            {
                if (!used[elmIdx])
                {
                    used[elmIdx] = true;
                    permutation[index] = elements[elmIdx];
                    Permute(index + 1);
                    used[elmIdx] = false;
                }
            }
        }

        private static void Permute2(int permutationsIndex)
        {
            if (permutationsIndex >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Permute2(permutationsIndex + 1);

            for (int i = permutationsIndex + 1; i < elements.Length; i++)
            {
                Swap(permutationsIndex, i);
                Permute2(permutationsIndex + 1);
                Swap(permutationsIndex, i);
            }
        }

        private static void Swap(int permutationsIndex, int i)
        {
            var temp = elements[i];
            elements[i] = elements[permutationsIndex];
            elements[permutationsIndex] = temp;
        }
    }
}
