using System;
using System.Linq;

namespace P03.MaximalSum
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

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowNums = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < rowNums.Length; col++)
                {
                    matrix[row, col] = rowNums[col];
                }
            }


            long maxSubMatrixSum = long.MinValue;
            int maxSumRow = 0;
            int maxSumCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 3 + 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 3 + 1; col++)
                {
                    int sumMatrixSum = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            sumMatrixSum += matrix[row + i, col + j];
                        }
                    }

                    if (maxSubMatrixSum < sumMatrixSum)
                    {
                        maxSubMatrixSum = sumMatrixSum;
                        maxSumRow = row;
                        maxSumCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSubMatrixSum}");

            for (int row = maxSumRow; row < maxSumRow + 3; row++)
            {
                for (int col = maxSumCol; col < maxSumCol + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

        }
    }
}
