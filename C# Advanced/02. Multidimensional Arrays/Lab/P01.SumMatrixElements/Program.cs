using System;
using System.Linq;

namespace P01.SumMatrixElements
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

            int matrixElementsSum = 0;

            foreach (var item in matrix)
            {
                matrixElementsSum += item;
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(matrixElementsSum);
        }
    }
}
