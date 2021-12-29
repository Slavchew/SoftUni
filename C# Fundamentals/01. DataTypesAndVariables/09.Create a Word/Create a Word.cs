using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Create_a_Word
{
    class Create_a_Word
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            string word = string.Empty;
            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                word += letter;
            }
            Console.WriteLine($"The word is: {word}");
        }
    }
}
