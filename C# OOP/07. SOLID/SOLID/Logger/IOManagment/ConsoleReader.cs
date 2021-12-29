using System;

using LoggerExercise.IOManagment.Contracts;

namespace LoggerExercise.IOManagment
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
