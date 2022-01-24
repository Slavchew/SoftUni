using System;
using System.Linq;

namespace P02.SumMatrixColumns
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
                int[] rowNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < rowNumbers.Length; col++)
                {
                    matrix[row, col] = rowNumbers[col];
                }
            }

            /*
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int colSum = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    colSum += matrix[row, col];
                }

                Console.WriteLine(colSum);
            }
            */


            int[] colSum = new int[matrix.GetLength(1)];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    colSum[col] += matrix[row, col];
                }
            }

            for (int i = 0; i < colSum.Length; i++)
            {
                Console.WriteLine(colSum[i]);
            }
        }
    }
}
