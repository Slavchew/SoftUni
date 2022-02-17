using System;
using System.Collections.Generic;

namespace P05.LongestCommonSubsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var table = new int[str1.Length + 1, str2.Length + 1];

            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (str1[r - 1] == str2[c - 1])
                    {
                        table[r, c] = table[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        table[r, c] = Math.Max(table[r - 1, c], table[r, c - 1]);
                    }
                }
            }

            var row = str1.Length;
            var col = str2.Length;

            var stack = new Stack<char>();
            while (row > 0 && col > 0)
            {
                if (str1[row - 1] == str2[col - 1])
                {
                    row--;
                    col--;

                    stack.Push(str1[row]);
                } 
                else if (table[row - 1, col] > table[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            Console.WriteLine(String.Join(" ", stack));
        }
    }
}
