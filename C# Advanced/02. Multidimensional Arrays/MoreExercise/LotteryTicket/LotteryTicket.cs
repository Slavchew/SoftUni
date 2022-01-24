using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryTicket
{
    class LotteryTicket
    {
        static void Main(string[] args)
        {
            int[] lens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = lens[0];
            int cols = lens[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowArray[col];
                }
            }

            var mainDiagonalSum = 0;
            var secondaryDiagonalSum = 0;
            var overMainDiagonalSum = 0;
            var underMainDiagonalSum = 0;
            int evenNumOnMainDiagSum = 0;
            int evenNumOnOuterRowsSum = 0;
            int oddNumOnOuterColsSum = 0;

            bool isWinning = false;
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        mainDiagonalSum += matrix[row, col];
                        if (matrix[row, col] % 2 == 0)
                        {
                            evenNumOnMainDiagSum += matrix[row, col];
                        }
                    }
                    else if (row < col)
                    {
                        overMainDiagonalSum += matrix[row, col];
                    }
                    else if (row > col)
                    {
                        underMainDiagonalSum += matrix[row, col];
                    }

                    if ((row + col) == rows - 1)
                    {
                        secondaryDiagonalSum += matrix[row, col];
                    }

                    if (row == 0 || row == rows - 1)
                    {
                        if (matrix[row, col] % 2 == 0)
                        {
                            evenNumOnOuterRowsSum += matrix[row, col];
                        }
                    }
                    if (col == 0 || col == cols - 1)
                    {
                        if (matrix[row, col] % 2 == 1)
                        {
                            oddNumOnOuterColsSum += matrix[row, col];
                        }
                    }
                }
            }

            bool condition1 = mainDiagonalSum == secondaryDiagonalSum;
            bool condition2 = overMainDiagonalSum % 2 == 0;
            bool condition3 = underMainDiagonalSum % 2 == 1;

            if (condition1 && condition2 && condition3)
            {
                isWinning = true;
            }

            double winningPrice = underMainDiagonalSum + evenNumOnMainDiagSum + evenNumOnOuterRowsSum + oddNumOnOuterColsSum;
            winningPrice /= 4.0;

            if (isWinning)
            {
                Console.WriteLine("YES");
                Console.WriteLine("The amount of money won is: {0:f2}",winningPrice);
                return;
            }
            Console.WriteLine("NO");
        }
    }
}
