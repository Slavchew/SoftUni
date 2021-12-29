using SillyGame.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SillyGame.IO
{
    class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
