using System;
using System.Linq;

namespace P09.Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int playerRow = 0;
            int playerCol = 0;

            int coalCount = 0;

            string[] directions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                for (int col = 0; col < rowElements.Length; col++)
                {
                    matrix[row, col] = rowElements[col];

                    if (matrix[row, col] == 's')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    else if (matrix[row, col] == 'c')
                    {
                        coalCount++;
                    }
                }
            }

            bool hasWon = false;
            int collectedCoal = 0;
            foreach (var direction in directions)
            {
                int nextRow = 0;
                int nextCol = 0;

                hasWon = false;

                if (direction == "left")
                {
                    nextCol = -1;
                }
                else if (direction == "right")
                {
                    nextCol = 1;
                }
                else if (direction == "up")
                {
                    nextRow = -1;
                }
                else if (direction == "down")
                {
                    nextRow = 1;
                }

                matrix[playerRow, playerCol] = '*';

                if (!IsInside(matrix, playerRow + nextRow, playerCol + nextCol))
                {
                    continue;
                }
                else
                {
                    playerRow += nextRow;
                    playerCol += nextCol;

                    if (matrix[playerRow, playerCol] == 'e')
                    {
                        hasWon = true;
                        Console.WriteLine($"Game over! ({playerRow}, {playerCol})");
                        Environment.Exit(0);
                    }

                    if (matrix[playerRow, playerCol] == 'c')
                    {
                        collectedCoal++;
                    }

                    if (collectedCoal == coalCount)
                    {
                        hasWon = true;
                        Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol})");
                        Environment.Exit(0);
                    }

                    matrix[playerRow, playerCol] = 's';
                }
            }

            if (!hasWon)
            {
                Console.WriteLine($"{coalCount - collectedCoal} coals left. ({playerRow}, {playerCol})");
            }
        }

        private static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
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
