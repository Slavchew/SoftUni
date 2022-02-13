using System;
using System.Linq;

namespace P04.InsertionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            InsertionSort(nums);

            Console.WriteLine(string.Join(" ", nums));
        }

        private static void InsertionSort(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                var j = i;
                while (j > 0 && nums[j - 1] > nums[j])
                {
                    Swap(nums, j, j - 1);
                    j--;
                }
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
