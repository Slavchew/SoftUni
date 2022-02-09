using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.Cinema
{
    internal class Program
    {
        private static List<string> people;
        private static string[] permutations;
        private static List<int> takenPositions;
        private static List<int> skipPositions;
        private static bool[] used;

        static void Main(string[] args)
        {
            people = Console.ReadLine().Split(", ").ToList();

            permutations = new string[people.Count];
            used = new bool[people.Count];
            takenPositions = new List<int>();
            skipPositions = new List<int>();

            var cmdArgs = Console.ReadLine().Split(" - ");
            while (cmdArgs[0] != "generate")
            {
                var name = cmdArgs[0];
                var position = int.Parse(cmdArgs[1]);

                permutations[position - 1] = name;
                takenPositions.Add(position - 1);

                people.Remove(name);

                cmdArgs = Console.ReadLine().Split(" - ");
            }

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= permutations.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }

            if (takenPositions.Contains(index))
            {
                Permute(index + 1);
                return;
            }

            for (int elmIdx = 0; elmIdx < people.Count; elmIdx++)
            {
                if (!used[elmIdx])
                {
                    used[elmIdx] = true;
                    permutations[index] = people[elmIdx];
                    Permute(index + 1);
                    used[elmIdx] = false;
                }
            }
        }
    }
}
