using System;

namespace Demo
{
    public class ConsoleWriteLinePersonObserver : IPersonObserver
    {
        public void Handle(string property)
        {
            Console.WriteLine($"Person changed: {property}");
        }
    }
}
