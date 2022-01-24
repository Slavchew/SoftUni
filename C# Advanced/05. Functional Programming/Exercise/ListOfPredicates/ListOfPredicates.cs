using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                bool isDiv = true;
                foreach (var num in nums)
                {
                    if (i % num != 0)
                    {
                        isDiv = false;
                        break;
                    }
                }
                if (isDiv)
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
