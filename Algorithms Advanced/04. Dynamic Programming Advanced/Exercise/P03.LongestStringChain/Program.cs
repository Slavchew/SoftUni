using System;
using System.Collections.Generic;

namespace P03.LongestStringChain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split();

            var len = new int[words.Length];
            var prev = new int[words.Length];

            var bestLength = 0;
            var lastIndex = 0;

            for (int i = 0; i < words.Length; i++)
            {
                prev[i] = -1;

                var currentWord = words[i];
                var currentBestSeq = 1;

                for (int j = i - 1; j >= 0; j--)
                {
                    var prevWord = words[j];

                    if (prevWord.Length < currentWord.Length && len[j] + 1 >= currentBestSeq)
                    {
                        currentBestSeq = len[j] + 1;
                        prev[i] = j;
                    }
                }

                if (currentBestSeq > bestLength)
                {
                    bestLength = currentBestSeq;
                    lastIndex = i;
                }

                len[i] = currentBestSeq;
            }

            var sequence = new Stack<string>();
            while (lastIndex != -1)
            {
                sequence.Push(words[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
