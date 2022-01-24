using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses
{
    class NoughtsAndCrosses
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[3,3];

            // ASCII Table
            // X -> 88     3*88 = 264 
            // O -> 79     3*79 = 237 
            // - -> 45     3*45 = 135

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowArray = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowArray[col];
                }
            }

            var mainDiagonalSum = 0;
            var secondaryDiagonalSum = 0;
            var rowSum = 0;
            var col0Sum = 0;
            var col1Sum = 0;
            var col2Sum = 0;

            //bool isWinning = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                rowSum = 0;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        mainDiagonalSum += matrix[row, col];
                    }

                    if ((row + col) == 2)
                    {
                        secondaryDiagonalSum += matrix[row, col];
                    }

                    if (col == 0)
                    {
                        col0Sum += matrix[row, col];
                    }
                    else if (col == 1)
                    {
                        col1Sum += matrix[row, col];
                    }
                    else if (col == 2)
                    {
                        col2Sum += matrix[row, col];
                    }

                    rowSum += matrix[row, col];
                }
            }

            if (mainDiagonalSum == 264 || secondaryDiagonalSum == 264 || rowSum == 264 ||
                col0Sum == 264 || col1Sum == 264 || col2Sum == 264)
            {
                Console.WriteLine("The winner is: X");
            }
            else if (mainDiagonalSum == 237 || secondaryDiagonalSum == 237 || rowSum == 237 ||
                     col0Sum == 237 || col1Sum == 237 || col2Sum == 237)
            {
                Console.WriteLine("The winner is: O");
            }
            else
            {
                Console.WriteLine("There is no winner");
            }
        }
    }
}
