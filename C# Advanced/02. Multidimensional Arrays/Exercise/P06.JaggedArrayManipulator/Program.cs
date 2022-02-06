using System;
using System.Linq;

namespace P06.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[n][];

            for (int i = 0; i < n; i++)
            {
                int[] rowNumbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                jaggedArray[i] = new double[rowNumbers.Length];
                for (int j = 0; j < rowNumbers.Length; j++)
                {
                    jaggedArray[i][j] = rowNumbers[j];
                }
            }


            for (int i = 0; i < jaggedArray.Length - 1; i++)
            {
                if (jaggedArray[i].Length == jaggedArray[i + 1].Length)
                {
                    jaggedArray[i] = jaggedArray[i].Select(x => x * 2).ToArray();
                    jaggedArray[i + 1] = jaggedArray[i + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    jaggedArray[i] = jaggedArray[i].Select(x => x / 2).ToArray();
                    jaggedArray[i + 1] = jaggedArray[i + 1].Select(x => x / 2).ToArray();
                }
            }

            string[] cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (cmdArgs[0].ToLower() != "end")
            {
                string cmdType = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (row < 0 || row >= jaggedArray.Length || 
                    col < 0 || col >= jaggedArray[row].Length)
                {
                    cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                if (cmdType.ToLower() == "add")
                {
                    jaggedArray[row][col] += value;
                }
                else if (cmdType.ToLower() == "subtract")
                {
                    jaggedArray[row][col] -= value;
                }

                cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            PrintJaggedArray(jaggedArray);
        }

        private static void PrintJaggedArray(double[][] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[i]));
            }
        }
    }
}
