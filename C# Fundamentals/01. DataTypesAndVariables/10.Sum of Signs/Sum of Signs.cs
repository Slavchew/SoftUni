using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Sum_of_Signs
{
    class Sum_of_Signs
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int letterSum = 0;
            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                letterSum += (int)letter;
            }
            Console.WriteLine($"The sum equals: {letterSum}");
        }
    }
}
