using NetCoreDI.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDI.IO
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
