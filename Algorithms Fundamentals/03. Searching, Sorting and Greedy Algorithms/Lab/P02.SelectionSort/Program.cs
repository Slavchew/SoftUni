using System;
using System.Linq;

namespace P02.SelectionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            SelectionSort(nums);

            Console.WriteLine(string.Join(" ", nums));
        }

        private static void SelectionSort(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                var min = i;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] < nums[min])
                    {
                        min = j;
                    }
                }

                Swap(nums, i, min);
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
