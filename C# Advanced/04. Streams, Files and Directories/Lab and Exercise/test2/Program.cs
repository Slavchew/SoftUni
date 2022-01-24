using System;
using System.Collections.Generic;
using System.Linq;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> str = new List<string>() { "kur", "ta" , "54554", "add", "4848"};

            var start = 0;
            var end = 3;
            str[start] = str.Skip(str.Count - start).Take(end).ToString();
        }
    }
}
