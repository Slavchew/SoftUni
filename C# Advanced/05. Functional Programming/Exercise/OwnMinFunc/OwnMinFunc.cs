using System;
using System.Collections.Generic;
using System.Linq;

namespace OwnMinFunc
{
    class OwnMinFunc
    {
        static void Main(string[] args)
        {
            Func<string, int> func = x => int.Parse(x);

            List<int> nums = Console.ReadLine()
                .Split()
                .Select(func)
                .ToList();

            Console.WriteLine(nums.Min());


        }
    }
}
