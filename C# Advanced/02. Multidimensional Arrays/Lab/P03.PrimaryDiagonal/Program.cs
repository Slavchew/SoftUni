using System;
using System.Linq;

namespace P03.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];
            for (int row = 0; row < matrixSize; row++)
            {
                int[] rowNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = rowNumbers[col];
                }
            }

            long mainDiagonalSum = 0;
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (row == col)
                    {
                        mainDiagonalSum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(mainDiagonalSum);
        }
    }
}
