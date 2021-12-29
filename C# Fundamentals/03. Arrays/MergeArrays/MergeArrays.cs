using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeArrays
{
    class MergeArrays
    {
        static void Main(string[] args)
        {
            int[] sequence1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] sequence2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var seq1Len = sequence1.Length;
            var seq2Len = sequence2.Length;
            var n = seq1Len + seq2Len;
            int[] seqMerged = new int[n];
            for (int i = 0; i < seq1Len; i++)
            {
                seqMerged[i] = sequence1[i];
            }
            var index = 0;
            for (int i = seq1Len; i < n; i++)
            {
                seqMerged[i] = sequence2[index];
                index++;
            }

            Array.Sort(seqMerged);
            Console.WriteLine(string.Join(" ",seqMerged));
        }
    }
}
