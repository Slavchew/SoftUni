using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelrahSnake
{
    class MelrahSnake
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = Console.ReadLine();
            while (pattern.Length > 0)
            {
                int firstIndex = input.IndexOf(pattern);
                int lastIndex = input.LastIndexOf(pattern);

                if (firstIndex != lastIndex)
                {
                    input = input.Remove(lastIndex, pattern.Length);

                    input = input.Remove(firstIndex, pattern.Length);

                    pattern = pattern.Remove(pattern.Length / 2, 1);

                    Console.WriteLine("Shaked it.");
                }

                else
                {
                    break;
                }
            } 
            Console.WriteLine("No shake.");
            Console.WriteLine(input);

        }
    }
}
