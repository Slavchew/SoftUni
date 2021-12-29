using System;
using System.Linq;
using System.Text;

namespace Punctoation
{
    class Punctuation
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= 'a' && input[i] <= 'z')
                {
                    var ch = input[i].ToString().ToUpper();
                    sb.Append(ch);
                }
                else if (input[i] >= 'A' && input[i] <= 'Z')
                {
                    var ch = input[i].ToString().ToLower();
                    sb.Append(ch);
                }
                else if (Char.IsDigit(input[i]))
                {
                    var num = int.Parse(input[i].ToString());
                    var ch = num * 2;
                    sb.Append(ch);
                }
                else
                {
                    string filter = "!#%&()*-.:,?@[]_{}";
                    foreach (var sym in filter)
                    {
                        if (input[i] == sym)
                        {
                            sb.Append(".");
                        }
                    }
                }
            }

            var result = sb.ToString().ToCharArray().ToList();
            result.Reverse();

            Console.WriteLine(string.Join("",result));
        }
    }
}
