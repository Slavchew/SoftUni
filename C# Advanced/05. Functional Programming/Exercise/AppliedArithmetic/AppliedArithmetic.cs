using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetic
{
    class AppliedArithmetic
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "add")
                {
                    nums = nums.Select(x => x += 1)
                        .ToList();
                }
                else if (command == "substract")
                {
                    nums = nums.Select(x => x -= 1)
                        .ToList();
                }
                else if (command == "multiply")
                {
                    nums = nums.Select(x => x *= 2)
                        .ToList();
                }
                else if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", nums));
                }
            }
        }
    }
}
