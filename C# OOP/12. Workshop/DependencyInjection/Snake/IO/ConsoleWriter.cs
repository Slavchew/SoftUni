using Snake.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.IO
{
    class ConsoleWriter : IWriter
    {
        public void Write(string str)
        {
            Console.WriteLine(str);
        }
    }
}
