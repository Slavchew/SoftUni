using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNumInSortedArray
{
    class InsertNumInSortedArray
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] seqUpdate = new int[sequence.Length + 1];
            int addedNum = int.Parse(Console.ReadLine());
            for (int i = 0; i < sequence.Length; i++)
            {
                seqUpdate[i] = sequence[i];
            }
            seqUpdate[seqUpdate.Length - 1] = addedNum;
            Array.Sort(seqUpdate);
            Console.WriteLine(string.Join(" ",seqUpdate));

            //int[] sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //int[] seqUpdate = new int[sequence.Length + 1];
            //int addedNum = int.Parse(Console.ReadLine());
            //for (int i = 0; i < sequence.Length; i++)
            //{
            //    if (sequence[i] < addedNum)
            //    {
            //        if (addedNum < sequence[i + 1])
            //        {
            //            seqUpdate[i] = sequence[i];
            //            seqUpdate[i + 1] = addedNum;
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        seqUpdate[i] = 
            //    }
            //}
        }
    }
}
