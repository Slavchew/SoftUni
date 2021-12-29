using DI.Module;
using SillyGame.IO;
using SillyGame.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SillyGame.DI
{
    class ConfigureDI : AbstractModule
    {
        public override void Configure()
        {
            CreateMapping<IReader, ConsoleReader>();
            CreateMapping<IWriter, ConsoleWriter>();
            CreateMapping<IWriter, WeirdConsoleWriter>();
        }
    }
}
