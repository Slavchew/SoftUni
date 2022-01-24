using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "input.txt";
            string pattern = @"[-,.!?]";

            RegexOptions options = RegexOptions.Multiline;

            StreamReader streamReader = new StreamReader(fileName);

            using (streamReader)
            {
                string line = streamReader.ReadLine();
                int counter = 0;


                while (line != null)
                {
                    if (counter % 2 == 0)
                    {
                        foreach (Match m in Regex.Matches(line, pattern, options))
                        {
                            line = line.Replace(m.ToString(), "@");
                        }

                        string[] words = line.Split().ToArray();

                        Console.WriteLine(string.Join(" ", words.Reverse()));
                    }

                    counter++;
                    line = streamReader.ReadLine();
                }
            }

        }
    }
}
