using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.LongestIncreasingSubsequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var len = new int[numbers.Length];
            var prev = new int[numbers.Length];

            var bestLength = 0;
            var lasIndex = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                prev[i] = -1;

                var currentNumber = numbers[i];
                var currentBestSeq = 1;

                for (int j = i - 1; j >= 0; j--)
                {
                    var prevNumber = numbers[j];

                    if (prevNumber < currentNumber && len[j] + 1 >= currentBestSeq)
                    {
                        currentBestSeq = len[j] + 1;
                        prev[i] = j;
                    }
                }

                if (currentBestSeq > bestLength)
                {
                    bestLength = currentBestSeq;
                    lasIndex = i;
                }

                len[i] = currentBestSeq;
            }

            var sequence = new Stack<int>();
            while (lasIndex != -1)
            {
                sequence.Push(numbers[lasIndex]);
                lasIndex = prev[lasIndex];
            }

            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
