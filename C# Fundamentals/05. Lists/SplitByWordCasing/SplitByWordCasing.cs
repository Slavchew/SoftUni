using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitByWordCasing
{
    class SplitByWordCasing
    {
        static void Main(string[] args)
        {
            List<string> allWords = Console.ReadLine()
               .Split(new[] { ',', ';', ':', '.', '!', '(', ')', '\"', '\'', '\\', '/', '[', ']', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> lowercase = new List<string>();
            List<string> uppercase = new List<string>();
            List<string> mixed = new List<string>();

            foreach (var word in allWords)
            {
                var loweraseChar = false;
                var uppercaseChar = false;

                for (int i = 0; i < word.Length; i++)
                {
                    if (char.IsUpper(word[i]))
                    {
                        uppercaseChar = true;
                    }
                    else if (char.IsLower(word[i]))
                    {
                        loweraseChar = true;
                    }
                    else
                    {
                        loweraseChar = false;
                        uppercaseChar = false;
                        break;
                    }


                    if (uppercaseChar == true && loweraseChar == true) break;
                }

                if (uppercaseChar == true && loweraseChar == false)
                {
                    uppercase.Add(word);
                }
                else if (uppercaseChar == false && loweraseChar == true)
                {
                    lowercase.Add(word);
                }
                else if (uppercaseChar == true && loweraseChar == true || uppercaseChar == false && loweraseChar == false)
                {
                    mixed.Add(word);
                }
            }

            Console.WriteLine("Lower-case: " + string.Join(", ",lowercase));
            Console.WriteLine("Mixed-case: " + string.Join(", ", mixed));
            Console.WriteLine("Upper-case: " + string.Join(", ", uppercase));
        }
    }
}
