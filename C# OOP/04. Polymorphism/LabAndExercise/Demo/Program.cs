using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            Shape shape = new Rectangle();

            if (shape is Rectangle)
            {
                ((Rectangle)shape).
            }

            var input = Console.ReadLine();
            while (true)
            {
                Shape baseClass;
                if (input == "square")
                {
                    baseClass = new Square() { A = 3 };
                }
                else
                {
                    baseClass = new Rectangle() { A = 5, B = 6 };
                }
                Console.WriteLine(baseClass.Area());
            }
        }
    }
}
