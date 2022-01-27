using System;
using System.Linq;

namespace P08.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] rowNums = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < rowNums.Length; col++)
                {
                    matrix[row, col] = rowNums[col];
                }
            }

            string[] bombsCordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var bomb in bombsCordinates)
            {
                int[] bombCordinates = bomb
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                int bombRow = bombCordinates[0];
                int bombCol = bombCordinates[1];
                int bombValue = matrix[bombRow, bombCol];

                if (matrix[bombRow, bombCol] <= 0)
                {
                    continue;
                }

                matrix[bombRow, bombCol] -= bombValue;

                if (IsInside(matrix, bombRow - 1, bombCol - 1) &&
                    matrix[bombRow - 1, bombCol - 1] > 0)
                {
                    matrix[bombRow - 1, bombCol - 1] -= bombValue;
                }
                if (IsInside(matrix, bombRow, bombCol - 1) &&
                    matrix[bombRow, bombCol - 1] > 0)
                {
                    matrix[bombRow, bombCol - 1] -= bombValue;
                }
                if (IsInside(matrix, bombRow + 1, bombCol - 1) &&
                    matrix[bombRow + 1, bombCol - 1] > 0)
                {
                    matrix[bombRow + 1, bombCol - 1] -= bombValue;
                }
                if (IsInside(matrix, bombRow - 1, bombCol) &&
                    matrix[bombRow - 1, bombCol] > 0)
                {
                    matrix[bombRow - 1, bombCol] -= bombValue;
                }
                if (IsInside(matrix, bombRow + 1, bombCol) &&
                    matrix[bombRow + 1, bombCol] > 0)
                {
                    matrix[bombRow + 1, bombCol] -= bombValue;
                }
                if (IsInside(matrix, bombRow - 1, bombCol + 1) &&
                    matrix[bombRow - 1, bombCol + 1] > 0)
                {
                    matrix[bombRow - 1, bombCol + 1] -= bombValue;
                }
                if (IsInside(matrix, bombRow, bombCol + 1) &&
                    matrix[bombRow, bombCol + 1] > 0)
                {
                    matrix[bombRow, bombCol + 1] -= bombValue;
                }
                if (IsInside(matrix, bombRow + 1, bombCol + 1) &&
                    matrix[bombRow + 1, bombCol + 1] > 0)
                {
                    matrix[bombRow + 1, bombCol + 1] -= bombValue;
                }
            }


            int aliveCells = 0;
            int sumOfCells = 0;
            foreach (var item in matrix)
            {
                if (item > 0)
                {
                    aliveCells++;
                    sumOfCells += item;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumOfCells}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsInside(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
    }
}
