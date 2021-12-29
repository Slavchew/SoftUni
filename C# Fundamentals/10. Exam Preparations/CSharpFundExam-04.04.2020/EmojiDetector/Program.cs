using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberPattern = @"\d";
            string emojiPattern = @"(:{2}|\*{2})[A-Z][a-z]{2,}\1";
            Regex numReg = new Regex(numberPattern);
            Regex emojiReg = new Regex(emojiPattern);


            string text = Console.ReadLine();
            long coolTreshold = 1;
            numReg.Matches(text).Select(m => m.Value).Select(int.Parse).ToList().ForEach(x => coolTreshold *= x);

            var matches = emojiReg.Matches(text);
            int totalEmojis = matches.Count;
            List<string> coolEmojis = new List<string>();

            foreach (Match match in matches)
            {
                long coolLevel = match.Value.Substring(2, match.Value.Length - 4).ToCharArray().Sum(x => (int)x);
                if (coolLevel >= coolTreshold)
                {
                    coolEmojis.Add(match.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolTreshold}");
            Console.WriteLine($"{totalEmojis} emojis found in the text. The cool ones are:");
            foreach (var emoji in coolEmojis)
            {
                Console.WriteLine(emoji);
            }
        }
    }
}
