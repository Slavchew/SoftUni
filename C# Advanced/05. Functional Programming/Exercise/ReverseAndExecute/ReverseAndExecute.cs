using System;
using System.Linq;

namespace ReverseAndExecute
{
    class ReverseAndExecute
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var n = int.Parse(Console.ReadLine());

            nums.Reverse();
            nums = nums.Where(x => x % n != 0).ToList();

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
