using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.ConnectingCables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var positions = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                positions[i] = i + 1;
            }

            var table = new int[numbers.Length + 1, numbers.Length + 1];

            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (numbers[r - 1] == positions[c - 1])
                    {
                        table[r, c] = table[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        table[r, c] = Math.Max(table[r - 1, c], table[r, c - 1]);
                    }
                }
            }

            Console.WriteLine($"Maximum pairs connected: {table[numbers.Length, numbers.Length]}");

            var row = numbers.Length;
            var col = positions.Length;

            var pairs = new List<int>();
            while (row > 0 && col > 0)
            {
                if (numbers[row - 1] == positions[col - 1])
                {
                    row--;
                    col--;

                    pairs.Add(numbers[row]);
                }
                else if (table[row - 1, col] > table[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            foreach (var pair in pairs)
            {
                Console.WriteLine($"{pair} - {pair}");
            }
        }
    }
}
