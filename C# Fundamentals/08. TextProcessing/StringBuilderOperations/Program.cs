using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] commands = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
            StringBuilder result = new StringBuilder();
            if (commands[0] == "Аppend")
            {
                result.Append(text);
            }
            else if (commands[0] == "Remove")
            {
                int startIndex = int.Parse(commands[1]);
                int len = int.Parse(commands[2]);
                result.Append(text);
                result.Remove(startIndex, len);
            }
            else if (commands[0] == "Insert")
            {
                int startIndex = int.Parse(commands[1]);
                string insertText = commands[2];
                result.Append(text);
                result.Insert(startIndex, insertText);
            }
            else if (commands[0] == "Replace")
            {
                string stringToReplace = commands[1];
                string newString = commands[2];
                result.Append(text);
                result.Replace(stringToReplace, newString);
            }
            Console.WriteLine(result);
        }
    }
}
