using System;
using System.Linq;

namespace P05.SnakeMoves
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

            string snake = Console.ReadLine();

            int snakeSizeCounter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (snakeSizeCounter == snake.Length)
                    {
                        snakeSizeCounter = 0;
                    }

                    if (row % 2 == 0)
                    {
                        matrix[row, col] = snake[snakeSizeCounter++];
                    }
                    else
                    {
                        matrix[row, matrix.GetLength(1) - 1 - col] = snake[snakeSizeCounter++];
                    }
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
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
    }
}
