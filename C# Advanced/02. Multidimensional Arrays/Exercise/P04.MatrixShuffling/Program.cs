using System;
using System.Linq;

namespace P04.MatrixShuffling
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

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] rowNums = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < rowNums.Length; col++)
                {
                    matrix[row, col] = rowNums[col];
                }
            }

            string[] cmdArg = Console.ReadLine().Split().ToArray();

            while (cmdArg[0] != "END")
            {
                if (cmdArg.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    cmdArg = Console.ReadLine().Split().ToArray();
                    continue;
                }

                string cmd = cmdArg[0];
                int row1 = int.Parse(cmdArg[1]);
                int col1 = int.Parse(cmdArg[2]);
                int row2 = int.Parse(cmdArg[3]);
                int col2 = int.Parse(cmdArg[4]);

                if (cmd != "swap" || (row1 < 0 || row1 >= matrix.GetLength(0))
                    || (col1 < 0 || col1 >= matrix.GetLength(1))
                    || (row2 < 0 || row2 >= matrix.GetLength(0))
                    || (col2 < 0 || col2 >= matrix.GetLength(1)))
                {
                    Console.WriteLine("Invalid input!");
                    cmdArg = Console.ReadLine().Split().ToArray();
                    continue;
                }


                string firstCell = matrix[row1, col1];
                string secondCell = matrix[row2, col2];

                matrix[row1, col1] = secondCell;
                matrix[row2, col2] = firstCell;

                PrintMatrix(matrix);

                cmdArg = Console.ReadLine().Split().ToArray();
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
