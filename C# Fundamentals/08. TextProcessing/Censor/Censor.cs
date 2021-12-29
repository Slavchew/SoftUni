using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Censor
{
    class Censor
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            string result = text.Replace(word, new string('*', word.Length));
            Console.WriteLine(result);
        }
    }
}
