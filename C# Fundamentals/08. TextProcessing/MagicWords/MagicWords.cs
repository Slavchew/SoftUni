using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWords
{
    class MagicWords
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            char[] reversed = new char[text.Length];

            string reversedText = ReverseString(text, reversed);

            if (text == reversedText)
                Console.WriteLine("True");
            else
                Console.WriteLine("False");

        }

        private static string ReverseString(string text, char[] reversed)
        {
            var count = 0;
            for (int i = text.Length - 1; i >= 0; i--)
            {
                reversed[count] = text[i];
                count++;
            }
            var reversedText = new string(reversed);
            return reversedText;
        }
    }
}
