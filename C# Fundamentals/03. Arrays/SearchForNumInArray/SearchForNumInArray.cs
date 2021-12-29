using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchForNumInArray
{
    class SearchForNumInArray
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int addedNum = int.Parse(Console.ReadLine());
            bool contain = false;
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == addedNum)
                {
                    Console.WriteLine("Yes");
                    contain = true;
                    break;
                }
            }
            if (!contain)
            {
                Console.WriteLine("No");
            }

            //if (sequence.Contains(addedNum))
            //{
            //    Console.WriteLine("Yes");
            //}
            //else
            //{
            //    Console.WriteLine("No");
            //}
        }
    }
}
