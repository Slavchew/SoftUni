using NetCoreDI.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDI
{
    class Engine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                writer.Write("working");
            }
        }
    }
}
