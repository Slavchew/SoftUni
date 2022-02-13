using System;
using System.Linq;

namespace P05.Quicksort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Quicksort(nums, 0, nums.Length - 1);

            Console.WriteLine(string.Join(" ", nums));
        }

        private static void Quicksort(int[] nums, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivot = start;
            var left = start + 1;
            var right = end;

            while (left <= right)
            {
                if (nums[left] > nums[pivot] && nums[pivot] > nums[right])
                {
                    Swap(nums, left, right);
                }

                if (nums[left] <= nums[pivot])
                {
                    left++;
                }

                if (nums[right] >= nums[pivot])
                {
                    right--;
                }
            }

            Swap(nums, pivot, right);

            var isSubLeftArraySmaller = right - 1 - start < end - (right + 1);

            if (isSubLeftArraySmaller)
            {
                Quicksort(nums, start, right - 1);
                Quicksort(nums, right + 1, end);
            }
            else
            {
                Quicksort(nums, right + 1, end);
                Quicksort(nums, start, right - 1);
            }
        }

        private static void Swap(int[] nums, int i, int min)
        {
            var temp = nums[i];
            nums[i] = nums[min];
            nums[min] = temp;
        }
    }
}
