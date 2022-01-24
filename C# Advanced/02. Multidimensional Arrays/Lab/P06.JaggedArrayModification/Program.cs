using System;
using System.Linq;

namespace P06.JaggedArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jaggedArr = new int[n][];

            for (int i = 0; i < n; i++)
            {
                int[] rowNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                jaggedArr[i] = new int[rowNumbers.Length];

                for (int j = 0; j < rowNumbers.Length; j++)
                {
                    jaggedArr[i][j] = rowNumbers[j];
                }
            }

            string[] cmdArg = Console.ReadLine().Split().ToArray();
            while (cmdArg[0] != "END")
            {
                string cmd = cmdArg[0];
                int arrIndex = int.Parse(cmdArg[1]);
                int arrElement = int.Parse(cmdArg[2]);
                int value = int.Parse(cmdArg[3]);

                if (jaggedArr.Length - 1 < arrIndex || arrIndex < 0
                    || jaggedArr[arrIndex].Length - 1 < arrElement || arrElement < 0)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (cmd == "Add")
                {
                    jaggedArr[arrIndex][arrElement] += value;
                }
                else if (cmd == "Subtract")
                {
                    jaggedArr[arrIndex][arrElement] -= value;
                }

                cmdArg = Console.ReadLine().Split().ToArray();
            }


            for (int i = 0; i < jaggedArr.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArr[i]));
            }
        }
    }
}
