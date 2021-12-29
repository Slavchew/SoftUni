using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            char[] reversed = new char[text.Length];

            var count = 0;
            for (int i = text.Length - 1; i >= 0; i--)
            {
                reversed[count] = text[i];
                count++;
            }
            Console.WriteLine(reversed);
        }
    }
}
