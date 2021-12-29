using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombs
{
    class Bombs
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var bomb = nums[0];
            var power = nums[1];
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == bomb)
                {
                    int start = Math.Max(i - power, 0);
                    int end = Math.Min(i + power, input.Count - 1);
                    int lenght = end - start + 1;
                    input.RemoveRange(start, lenght);
                    i = 0;
                }
            }
            Console.WriteLine(string.Join(" ", input.Sum()));
        }
    }
}
