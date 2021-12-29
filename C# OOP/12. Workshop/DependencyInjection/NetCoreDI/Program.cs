using Microsoft.Extensions.DependencyInjection;
using NetCoreDI.IO;
using NetCoreDI.IO.Contracts;
using System;

namespace NetCoreDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IReader, ConsoleReader>()
                .AddSingleton<IWriter, ConsoleWriter>()
                .AddSingleton<Engine, Engine>()
                .BuildServiceProvider();

            Engine engine = serviceProvider.GetService<Engine>();

            engine.Run();
        }
    }
}
