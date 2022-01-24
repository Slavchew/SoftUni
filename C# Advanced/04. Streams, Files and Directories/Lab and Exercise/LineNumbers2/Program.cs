using System;
using System.IO;
using System.Text.RegularExpressions;

namespace LineNumbers2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "input.txt";
            string marksPattern = @"[.,?!;':-]";
            string letterPattern = @"[A-z]";

            RegexOptions options = RegexOptions.Multiline;

            StreamReader streamReader = new StreamReader(fileName);

            using (streamReader)
            {
                string line = streamReader.ReadLine();
                int lineCounter = 1;


                while (line != null)
                {
                    int marksCounter = 0;
                    int letterCounter = 0;

                    foreach (Match m in Regex.Matches(line, marksPattern, options))
                    {
                        marksCounter++;
                    }

                    foreach (Match m in Regex.Matches(line, letterPattern, options))
                    {
                        letterCounter++;
                    }

                    line = $"Line {lineCounter}: {line} ({letterCounter})({marksCounter})";

                    Console.WriteLine(line);

                    lineCounter++;

                    line = streamReader.ReadLine();
                }
            }
        }
    }
}
