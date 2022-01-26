using System;
using System.Linq;

namespace P01.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] rowNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < rowNums.Length; col++)
                {
                    matrix[row, col] = rowNums[col];
                }
            }

            int mainDiagonal = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        mainDiagonal += matrix[row, col];
                    }
                }
            }

            int secondaryDiagonal = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if ((row + col) == (n - 1))
                    {
                        secondaryDiagonal += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(mainDiagonal - secondaryDiagonal));
        }
    }
}
