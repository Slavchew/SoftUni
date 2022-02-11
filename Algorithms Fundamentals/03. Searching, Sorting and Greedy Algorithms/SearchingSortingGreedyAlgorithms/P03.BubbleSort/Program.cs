using System;
using System.Linq;

namespace P03.BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            BubbleSort(nums);

            Console.WriteLine(string.Join(" ", nums));
        }

        private static void BubbleSort(int[] nums)
        {
            var isSorted = false;
            var i = 0;
            while (!isSorted)
            {
                isSorted = true;
                for (int j = 1; j < nums.Length - i; j++)
                {
                    if (nums[j - 1] > nums[j])
                    {
                        isSorted = false;
                        Swap(nums, j - 1, j);
                    }
                }

                i++;
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
