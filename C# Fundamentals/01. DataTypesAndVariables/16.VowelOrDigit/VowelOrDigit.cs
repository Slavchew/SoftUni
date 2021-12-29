using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.VowelOrDigit
{
    class VowelOrDigit
    {
        static void Main(string[] args)
        {
            char unit = char.Parse(Console.ReadLine());
            switch (unit)
            {
                case 'A':
                case 'a':
                case 'O':
                case 'o':
                case 'U':
                case 'u':
                case 'E':
                case 'e':
                case 'I':
                case 'i':
                    Console.WriteLine("vowel");
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    Console.WriteLine("digit");
                    break;
                default:
                    Console.WriteLine("other");
                    break;
            }
        }
    }
}
