using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("words.txt");
            string[] lines = File.ReadAllLines("text.txt");

            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string pattern = @$"\b{word}";

                result.Add(word, 0);

                for (int i = 0; i < lines.Length; i++)
                {
                    foreach (Match m in Regex.Matches(lines[i].ToLower(), pattern))
                    {
                        result[word]++;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach (var item in result.OrderByDescending(x => x.Value))
            {
                sb.AppendLine($"{item.Key} - {item.Value}");
            }

            File.WriteAllText("actualResult.txt", sb.ToString());
        }
    }
}
