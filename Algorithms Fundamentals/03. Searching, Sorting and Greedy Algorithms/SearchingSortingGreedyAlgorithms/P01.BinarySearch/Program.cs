using System;
using System.Linq;

namespace P01.BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var element = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(nums, element));
        }

        private static int BinarySearch(int[] nums, int element)
        {
            var start = 0;
            var end = nums.Length - 1;
            int mid;

            while (start <= end)
            {
                mid = (start + end) / 2;

                if (element == nums[mid])
                {
                    return mid;
                }

                if (element > nums[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }

            }

            return -1;
        }
    }
}
