using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldAndSum
{
    class FoldAndSum
    {
        static void Main(string[] args)
        {

            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int kTimes = array.Length / 4;
            int[] firstHalfFirstLine = new int[kTimes];
            int[] secondHalfFirstLine = new int[kTimes];
            int[] secondLine = new int[kTimes * 2];
            int[] sum = new int[kTimes * 2];
            for (int i = 0; i < kTimes; i++)
            {
                firstHalfFirstLine[i] = array[kTimes - 1 - i];
                secondHalfFirstLine[i] = array[array.Length - 1 - i];
            }

            for (int i = 0; i < kTimes * 2; i++)
            {
                secondLine[i] = array[kTimes + i];
            }

            for (int i = 0; i < kTimes; i++)
            {
                sum[i] = firstHalfFirstLine[i] + secondLine[i];
            }

            for (int i = 0; i < kTimes; i++)
            {
                sum[i + kTimes] = secondHalfFirstLine[i] + secondLine[i + kTimes];
            }

            Console.WriteLine(string.Join(" ", sum));

            ///Short and working solution

            //int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //int middleStartIndex = sequence.Length / 4;
            //int middleEndIndex = middleStartIndex + sequence.Length / 2;

            //int summingIndex = middleStartIndex - 1;

            //for (int i = middleStartIndex; i < middleEndIndex; i++)
            //{
            //    int sum = sequence[i] + sequence[summingIndex];
            //    Console.Write($"{sum} ");
            //    summingIndex--;
            //    if (summingIndex < 0)
            //    {
            //        summingIndex = sequence.Length - 1;
            //    }
            //}
        }
    }
}
