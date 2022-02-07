using System;
using System.Collections.Generic;

namespace P02.PermutationsWithRepetitions
{
    internal class Program
    {
        private static string[] elements;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();

            Permute(0);
        }

        private static void Permute(int permutationsIndex)
        {
            if (permutationsIndex >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Permute(permutationsIndex + 1);
            var swapped = new HashSet<string> { elements[permutationsIndex] };

            for (int i = permutationsIndex + 1; i < elements.Length; i++)
            {
                if (!swapped.Contains(elements[i]))
                {
                    Swap(permutationsIndex, i);
                    Permute(permutationsIndex + 1);
                    Swap(permutationsIndex, i);
                    swapped.Add(elements[i]);
                }
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
