using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings_and_Characters
{
    class Strings_and_Characters
    {
        static void Main(string[] args)
        {
            string text1 = Console.ReadLine();
            char letter1 = char.Parse(Console.ReadLine());
            char letter2 = char.Parse(Console.ReadLine());
            char letter3 = char.Parse(Console.ReadLine());
            string text2 = Console.ReadLine();

            Console.WriteLine($"{text1}\n{letter1}\n{letter2}\n{letter3}\n{text2}");

        }
    }
}
