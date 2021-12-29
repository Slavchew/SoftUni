using SillyGame.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SillyGame.IO
{
    class WeirdConsoleWriter : IWriter
    {
        public void Write(string str)
        {
            Console.WriteLine("Weirrrrd");
            Console.WriteLine(str);
        }
    }
}
