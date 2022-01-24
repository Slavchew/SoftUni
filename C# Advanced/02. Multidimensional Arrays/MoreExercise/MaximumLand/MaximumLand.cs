using System;
using System.Linq;

namespace MaximumLand
{
    class MaximumLand
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, cols];

            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowArray[col];
                }
            }

            var bestSum = int.MinValue;
            var sum = 0;
            var bestRowIndex = 0;
            var bestColIndex = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    sum = matrix[row, col] +
                        matrix[row, col + 1] +
                        matrix[row + 1, col] +
                        matrix[row + 1, col + 1];

                    if (bestSum < sum)
                    {
                        bestSum = sum;
                        bestRowIndex = row;
                        bestColIndex = col;
                    }
                }
            }

            for (int row = bestRowIndex; row < bestRowIndex + 2; row++)
            {
                for (int col = bestColIndex; col < bestColIndex + 2; col++)
                {
                    Console.Write("{0} ", matrix[row , col]);
                }
                Console.WriteLine();
            }
        }
    }
}
