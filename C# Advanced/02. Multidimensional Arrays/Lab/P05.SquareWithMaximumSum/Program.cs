using System;
using System.Linq;

namespace P05.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixSizes[0];
            int cols = matrixSizes[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowNumbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < rowNumbers.Length; col++)
                {
                    matrix[row, col] = rowNumbers[col];
                }
            }


            int[] subMatrixSizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int subRows = subMatrixSizes[0];
            int subCols = subMatrixSizes[1];

            long maxSubMatrixSum = long.MinValue;
            int maxSumRow = 0;
            int maxSumCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - subRows + 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - subCols + 1; col++)
                {
                    int sumMatrixSum = 0;
                    for (int i = 0; i < subRows; i++)
                    {
                        for (int j = 0; j < subCols; j++)
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

            for (int row = maxSumRow; row < maxSumRow + subRows; row++)
            {
                for (int col = maxSumCol; col < maxSumCol + subCols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSubMatrixSum);
        }
    }
}
