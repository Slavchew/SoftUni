using Snake.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.IO
{
    class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
