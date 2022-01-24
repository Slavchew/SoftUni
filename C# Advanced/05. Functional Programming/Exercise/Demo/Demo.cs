using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    class Demo
    {
        static void Main(string[] args)
        {
            Action<string> action = x => Console.WriteLine($"Sir {x}");

            Console.ReadLine()
                 .Split()
                 .ToList()
                 .ForEach(action);
        }
    }
}
