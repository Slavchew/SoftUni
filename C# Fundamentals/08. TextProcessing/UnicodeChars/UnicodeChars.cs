using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicodeChars
{
    class UnicodeChars
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().ToCharArray();
            foreach (var c in text)
            {
                Console.Write($"\\u{((int)c).ToString("X4").ToLower()}");
            }
        }
    }
}
