using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseArrayOfTexts
{
    class ReverseArrayOfTexts
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            for (int i = str.Length - 1; i >= 0 ; i--)
            {
                Console.Write("{0} ",str[i]);
            }
            Console.WriteLine();

            //string[] str = Console.ReadLine().Split(' ');
            //for (int i = 0; i < str.Length / 2; i++)
            //{
            //    var oldElement = str[i];
            //    str[i] = str[str.Length - i - 1];
            //    str[str.Length - i - 1] = oldElement;
            //}
            //Console.WriteLine(string.Join(" ", str));
        }
    }
}
