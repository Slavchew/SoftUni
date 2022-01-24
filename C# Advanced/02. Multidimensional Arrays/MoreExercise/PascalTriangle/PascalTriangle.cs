using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalTriangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());
            long[][] triangle = new long[h][];
            for (int row = 0; row < h; row++)
            {
                triangle[row] = new long[row + 1];
            }
            triangle[0][0] = 1;
            for (int row = 0; row < h - 1; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    triangle[row + 1][col] += triangle[row][col];
                    triangle[row + 1][col + 1] += triangle[row][col];
                }
            }

            for (int row = 0; row < h; row++)
            {
                Console.Write(" ".PadLeft((h - row) * 2));
                for (int col = 0; col <= row; col++)
                {
                    Console.Write("{0,3} ", triangle[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}
