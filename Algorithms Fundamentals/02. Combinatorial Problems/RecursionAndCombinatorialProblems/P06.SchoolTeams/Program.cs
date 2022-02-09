using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.SchoolTeams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var girls = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var boys = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            var girlsComb = new string[3];
            var girlsList = new List<string[]>();
            Comb(0, 0, girlsComb, girls, girlsList);

            var boyComb = new string[2];
            var boysList = new List<string[]>();
            Comb(0, 0, boyComb, boys, boysList);

            foreach (var currGirl in girlsList)
            {
                foreach (var currBoy in boysList)
                {
                    Console.WriteLine($"{string.Join(", ", currGirl)}, {string.Join(", ", currBoy)}");
                }
            }
        }

        private static void Comb(int cellIdx, int elementIdx, 
            string[] combination, List<string> elements, List<string[]> result)
        {
            if (cellIdx >= combination.Length)
            {
                result.Add(combination.ToArray());
                return;
            }

            for (int i = elementIdx; i < elements.Count; i++)
            {
                combination[cellIdx] = elements[i];
                Comb(cellIdx + 1, i + 1, combination, elements, result);
            }
        }
    }
}
