using System;
using System.Linq;

namespace UserComparator
{
    class UserComparator
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var left = nums.Where(x => x % 2 == 0)
                .ToArray();
            Array.Sort(left);

            var right = nums.Where(x => x % 2 != 0)
                .ToArray();
            Array.Sort(right);

            var result = left.Concat(right);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
