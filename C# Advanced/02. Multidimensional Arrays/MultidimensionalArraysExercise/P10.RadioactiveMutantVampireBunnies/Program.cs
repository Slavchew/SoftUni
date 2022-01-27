using System;
using System.Collections.Generic;
using System.Linq;

namespace P10.RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            char[,] matrix = new char[rows, cols];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowElements = Console.ReadLine().Trim();

                for (int col = 0; col < rowElements.Length; col++)
                {
                    matrix[row, col] = rowElements[col];

                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string directions = Console.ReadLine();

            foreach (var direction in directions)
            {
                int nextRow = 0;
                int nextCol = 0;

                if (direction == 'L')
                {
                    nextCol = -1;
                }
                else if (direction == 'R')
                {
                    nextCol = 1;
                }
                else if (direction == 'U')
                {
                    nextRow = -1;
                }
                else if (direction == 'D')
                {
                    nextRow = 1;
                }

                bool hasWon = false;
                bool isDead = false;

                matrix[playerRow, playerCol] = '.';

                if (!IsInside(matrix, playerRow + nextRow, playerCol + nextCol))
                {
                    hasWon = true;
                }
                else
                {
                    playerRow += nextRow;
                    playerCol += nextCol;

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        isDead = true;
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = 'P';
                    }
                }

                List<int[]> bunniesCordinates = new List<int[]>();

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            bunniesCordinates.Add(new int[] { row, col });
                        }
                    }
                }

                foreach (var item in bunniesCordinates)
                {
                    int bunnyRow = item[0];
                    int bunnyCol = item[1];

                    if (IsInside(matrix, bunnyRow + 1, bunnyCol))
                    {
                        if (matrix[bunnyRow + 1, bunnyCol] == 'P')
                        {
                            isDead = true;
                        }
                        matrix[bunnyRow + 1, bunnyCol] = 'B';
                    }
                    if (IsInside(matrix, bunnyRow - 1, bunnyCol))
                    {
                        if (matrix[bunnyRow - 1, bunnyCol] == 'P')
                        {
                            isDead = true;
                        }
                        matrix[bunnyRow - 1, bunnyCol] = 'B';
                    }
                    if (IsInside(matrix, bunnyRow, bunnyCol + 1))
                    {
                        if (matrix[bunnyRow, bunnyCol + 1] == 'P')
                        {
                            isDead = true;
                        }
                        matrix[bunnyRow, bunnyCol + 1] = 'B';
                    }
                    if (IsInside(matrix, bunnyRow, bunnyCol - 1))
                    {
                        if (matrix[bunnyRow, bunnyCol - 1] == 'P')
                        {
                            isDead = true;
                        }
                        matrix[bunnyRow, bunnyCol - 1] = 'B';
                    }
                }

                if (hasWon)
                {
                    Print(matrix);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    Environment.Exit(0);
                }

                if (isDead)
                {
                    Print(matrix);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    Environment.Exit(0);
                }
            }
        }

        private static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
    }
}
