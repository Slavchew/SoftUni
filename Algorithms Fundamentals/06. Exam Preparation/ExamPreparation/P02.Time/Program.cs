using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Time
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sequance1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var sequance2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var table = new int[sequance1.Length + 1, sequance2.Length + 1];

            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (sequance1[r - 1] == sequance2[c - 1])
                    {
                        table[r, c] = table[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        table[r, c] = Math.Max(table[r - 1, c], table[r, c - 1]);
                    }
                }
            }

            var row = sequance1.Length;
            var col = sequance2.Length;

            var result = new Stack<int>();

            while (row > 0 && col > 0)
            {
                if (sequance1[row - 1] == sequance2[col - 1])
                {
                    row--;
                    col--;

                    result.Push(sequance1[row]);
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

            Console.WriteLine(String.Join(" ", result));
            Console.WriteLine(table[sequance1.Length, sequance2.Length]);
        }
    }
}
