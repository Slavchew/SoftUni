using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseArrayOfStrings
{
    class ReverseArrayOfStrings
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            for (int i = 0; i < str.Length / 2; i++)
            {
                var oldElement = str[i];
                str[i] = str[str.Length - i - 1];
                str[str.Length - i - 1] = oldElement;
            }

            Console.WriteLine(string.Join(" ",str));
        }
    }
}
