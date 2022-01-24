using System;
using System.Collections.Generic;
using System.Linq;

namespace OddOrEvenNums
{
    class OddOrEvenNums
    {
        static void Main(string[] args)
        {
            Predicate<int> predicate;

            var range = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var input = Console.ReadLine();

            if (input == "odd")
            {
                predicate = n => n % 2 == 0;
            }
            else
            {
                predicate = n => n % 2 != 0;
            }

            var list = new List<int>();

            for (int i = range[0]; i <= range[1]; i++)
            {
                list.Add(i);
            }

            list.RemoveAll(predicate);

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
