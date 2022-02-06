using System;
using System.Linq;

namespace P02._2X2SquaresInMatrix
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

            for (int row = 0; row < rows; row++)
            {
                char[] rowNums = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int col = 0; col < rowNums.Length; col++)
                {
                    matrix[row, col] = rowNums[col];
                }
            }

            int equalMatrixesCount = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row, col + 1] == matrix[row + 1, col] &&
                        matrix[row + 1, col] == matrix[row + 1, col + 1])
                    {
                        equalMatrixesCount++;
                    }
                }
            }

            Console.WriteLine(equalMatrixesCount);
        }
    }
}
