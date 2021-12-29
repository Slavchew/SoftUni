using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArrayOfIntegers
{
    class SortArrayOfIntegers
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            //for (int i = 0; i < sequence.Length - 1; i++)
            //{
            //    for (int j = 0; j < sequence.Length - 1; j++)
            //    {
            //        if (sequence[j] > sequence[j + 1])
            //        {
            //            int swapVar = sequence[j];
            //            sequence[j] = sequence[j + 1];
            //            sequence[j + 1] = swapVar;
            //        }
            //    }
            //}

            Array.Sort(sequence);
            Console.WriteLine(string.Join(" ",sequence));
        }
    }
}
