using System;

namespace P04.SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            for (int row = 0; row < matrixSize; row++)
            {
                char[] rowSymbols = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = rowSymbols[col];
                }
            }

            char searchingSymbol = char.Parse(Console.ReadLine());
            bool isExist = false;
            for (int row = 0; row < matrixSize; row++)
            {
                /*
                if (isExist)
                {
                    break;
                }
                */

                for (int col = 0; col < matrixSize; col++)
                {
                    if (matrix[row, col] == searchingSymbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isExist = true;
                        goto LoopEnd;
                        break;
                    }
                }
            }

            LoopEnd:
            if (!isExist)
            {
                Console.WriteLine($"{searchingSymbol} does not occur in the matrix");
            }
        }
    }
}
