using System;

using LoggerExercise.IOManagment.Contracts;

namespace LoggerExercise.IOManagment
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
