using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tables
{
    class Tables
    {
        static void Main(string[] args)
        {
            int sheets = int.Parse(Console.ReadLine());
            int[][,] document = new int[sheets][,];

            for (int i = 0; i < sheets; i++)
            {

                int[] lens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int rows = lens[0];
                int cols = lens[1];

                document[i] = new int[rows, cols];

                for (int row = 0; row < rows; row++)
                {
                    int[] rowArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                    for (int col = 0; col < cols; col++)
                    {
                        document[i][row, col] = rowArray[col];
                    }
                }
            }

            double globalAvg = 0, localAvg = 0;
            int max = 0, min = 0;
            for (int i = 0; i < sheets; i++)
            {
                localAvg = 0;
                max = min = document[i][0, 0];

                for (int j = 0; j < document[i].GetLength(0); j++)
                {
                    for (int q = 0; q < document[i].GetLength(1); q++)
                    {
                        localAvg += document[i][j, q];
                        if (max < document[i][j, q]) max = document[i][j, q];
                        if (min > document[i][j, q]) min = document[i][j, q];
                    }
                }
                localAvg = localAvg / (document[i].GetLength(0) * document[i].GetLength(1));
                Console.WriteLine("{0} {1} {2}", min, max, Math.Round(localAvg, 2));
                globalAvg += localAvg;
            }
            globalAvg /= sheets;

            for (int i = 0; i < sheets; i++)
            {
                int count = 0;
                for (int j = 0; j < document[i].GetLength(0); j++)
                {
                    for (int q = 0; q < document[i].GetLength(1); q++)
                    {
                        if (document[i][j, q] > globalAvg) count++;
                    }
                }
                Console.Write("{0} ", count);
            }
            Console.WriteLine();
        }
    }
}
