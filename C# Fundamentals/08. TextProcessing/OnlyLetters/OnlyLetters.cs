using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyLetters
{
    class OnlyLetters
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string last = "", result = "";
            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(line[i]))
                {
                    if (last == "") result += last;
                    else if (i == 0)
                    {
                        result += last;
                    }
                    else
                    {
                        while (char.IsDigit(line[i - 1]))
                        {
                            i--;
                            if (i == 0)
                            {
                                break;
                            }
                        }
                        result += last;
                    }
                }
                else
                {
                    last = line[i].ToString();
                    result += line[i].ToString();
                }
            }
            Console.WriteLine(new string(result.Reverse().ToArray()));
        }
    }
}
