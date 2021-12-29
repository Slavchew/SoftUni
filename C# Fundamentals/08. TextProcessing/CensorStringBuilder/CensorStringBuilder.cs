using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensorStringBuilder
{
    class CensorStringBuilder
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            StringBuilder result = new StringBuilder(text);
            result = result.Replace(word, new string('*', word.Length));
            Console.WriteLine(result);
        }
    }
}
