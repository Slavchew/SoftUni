using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegExp
{
    class RegExp
    {
        static void Main(string[] args)
        {
            string pattern = @"((?:[1-2]?[0-9])|(?:3[0-1]))-([A-Z][a-z]{2})-([0-9]{4})";
            string whitespace = @"\s+";

            var regex = new Regex(pattern);
            //string text = "Today is 25-Nov-2020";
            //text = regex.Replace(text, "today");

            string text = "2         4   3 5 6   8    9        1  5";

            int[] arr = Regex.Split(text, whitespace).Select(int.Parse).ToArray();



            Console.WriteLine(text);
        }
    }
}
