using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinByCols
{
    class MinByCols
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

            int[] mins = new int[cols];
            for (int i = 0; i < mins.Length; i++)
            {
                mins[i] = int.MaxValue;
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,5}", matrix[row, col]);
                    if (matrix[row, col] < mins[col])
                    {
                        mins[col] = matrix[row, col];
                    }
                }
                Console.WriteLine();
            }
            for (int i = 0; i < mins.Length; i++)
            {
                Console.Write("{0,5}", mins[i]);
            }
        }
    }
}
