using System;

namespace Demo
{
    class Program
    {
        public delegate void DelegatePrint(string msg);
        static void Main(string[] args)
        {
            DelegatePrint del = Print1;
            del += Print2;
            del += Print3;

            del("da");
        }

        private static void Print1(string msg)
        {
            Console.WriteLine($"1: {msg}");
        }

        private static void Print2(string msg)
        {
            Console.WriteLine($"2: {msg}");
        }

        private static void Print3(string msg)
        {
            Console.WriteLine($"3: {msg}");
        }
    }
}
