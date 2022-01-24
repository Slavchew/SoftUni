using System;
using System.Collections.Generic;
using System.Linq;

namespace Inferno_III
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "Forge")
            {
                string cmdType = command[1];

                if (cmdType == "Exclude")
                {

                }
                else if (cmdType == "Reverse")
                {

                }


                command = Console.ReadLine().Split();
            }
        }
    }
}
