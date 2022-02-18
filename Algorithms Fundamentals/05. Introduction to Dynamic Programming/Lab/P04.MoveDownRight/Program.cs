using System;
using System.Linq;
using System.Collections.Generic;

namespace P04.MoveDownRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var numbers = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int c = 0; c < cols; c++)
                {
                    numbers[r, c] = line[c];
                }
            }

            var sums = new int[rows, cols];
            sums[0, 0] = numbers[0, 0];


            for (int c = 1; c < cols; c++)
            {
                sums[0, c] = sums[0, c - 1] + numbers[0, c];
            }

            for (int r = 1; r < rows; r++)
            {
                sums[r, 0] = sums[r - 1, 0] + numbers[r, 0];
            }

            for (int r = 1; r < sums.GetLength(0); r++)
            {
                for (int c = 1; c < sums.GetLength(1); c++)
                {
                    var upperCell = sums[r - 1, c];
                    var leftCell = sums[r, c - 1];
                    var max = Math.Max(upperCell, leftCell);

                    sums[r, c] = numbers[r, c] + max;
                }
            }


            var row = rows - 1;
            var col = cols - 1;
            var path = new Stack<string>();
            path.Push($"[{row}, {col}]");

            while (row >= 0 && col >= 0)
            {
                if (row == 0 && col == 0)
                {
                    break;
                }

                if (row == 0)
                {
                    col--;
                    path.Push($"[{row}, {col}]");
                    continue;
                }

                if (col == 0)
                {
                    row--;
                    path.Push($"[{row}, {col}]");
                    continue;
                }

                var upper = sums[row - 1, col];
                var left = sums[row, col - 1];

                if (upper > left)
                {
                    row--;
                }
                else
                {
                    col--;
                }

                path.Push($"[{row}, {col}]");
            }

            while (path.Count > 0)
            {
                Console.Write($"{path.Pop()} ");
            }
        }
    }
}
