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
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = nums.Length / 4;

            var row1left = nums.Take(k).Reverse();
            var row1right = nums.Reverse().Take(k);
            int[] row1 = row1left.Concat(row1right).ToArray();
            int[] row2 = nums.Skip(k).Take(k * 2).ToArray();

            var sum = row1.Select((x, index) => x + row2[index]);
            Console.WriteLine(string.Join(" ",sum));
        }
    }
}
