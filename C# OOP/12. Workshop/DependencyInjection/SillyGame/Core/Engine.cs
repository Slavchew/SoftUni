using DI.Attributes;
using SillyGame.IO;
using SillyGame.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SillyGame.Core
{
    class Engine
    {
        private IReader reader;
        private IWriter writer;

        [Inject]
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
