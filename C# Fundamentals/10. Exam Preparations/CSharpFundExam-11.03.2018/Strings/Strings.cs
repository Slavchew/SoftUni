using System;
using System.Collections.Generic;
using System.Linq;

namespace Strings
{
    class Strings
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            List<char> pattern = Console.ReadLine().ToList();


            while (pattern.Count > 0)
            {
                var stringPattern = string.Join("", pattern);
                var index = input.LastIndexOf(stringPattern);

                if (index == -1)
                {
                    break;
                }

                input = input.Remove(index, pattern.Count);

                var indexToRemove = pattern.Count / 2;
                pattern.RemoveAt(indexToRemove);
                pattern.Reverse();

            }

            Console.WriteLine(input);
        }
    }
}
