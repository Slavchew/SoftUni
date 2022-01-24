using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageOnRows
{
    class AverageOnRows
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = int.Parse(Console.ReadLine());
                }
            }

            double avg = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                avg = 0;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,10}", matrix[row, col]);
                    avg += matrix[row, col];
                }
                avg /= cols;
                Console.WriteLine("{0,10}", avg);
            }
        }
    }
}
