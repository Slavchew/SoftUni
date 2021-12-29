using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Motorcycle motorcycle = new Motorcycle(200, 50);
            motorcycle.Drive(20);
        }
    }
}
