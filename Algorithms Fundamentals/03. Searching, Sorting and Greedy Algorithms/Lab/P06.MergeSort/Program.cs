using System;
using System.Linq;

namespace P06.MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var sorted = MergeSort(nums);

            Console.WriteLine(string.Join(" ", sorted));
        }

        private static int[] MergeSort(int[] nums)
        {
            if (nums.Length <= 1)
            {
                return nums;
            }

            var left = nums.Take(nums.Length / 2).ToArray();
            var right = nums.Skip(nums.Length / 2).ToArray();

            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            var merged = new int[left.Length + right.Length];

            var leftIdx = 0;
            var rightIdx = 0;
            var mergedIdx = 0;

            while (leftIdx < left.Length && rightIdx < right.Length)
            {
                if (left[leftIdx] < right[rightIdx])
                {
                    merged[mergedIdx] = left[leftIdx];
                    leftIdx++;
                }
                else
                {
                    merged[mergedIdx] = right[rightIdx];
                    rightIdx++;
                }

                mergedIdx++;
            }

            while (leftIdx < left.Length)
            {
                merged[mergedIdx] = left[leftIdx];
                leftIdx++;
                mergedIdx++;
            }

            while (rightIdx < right.Length)
            {
                merged[mergedIdx] = right[rightIdx];
                rightIdx++;
                mergedIdx++;
            }


            return merged;
        }
    }
}
