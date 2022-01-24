using System;
using System.Linq;

namespace ListyExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ListyIterator<string> myListyIterator = new ListyIterator<string>();

            while (true)
            {
                var input = Console.ReadLine().Split().ToArray();
                if (input[0] == "END") break;

                try
                {
                    switch (input[0])
                    {
                        case "Create": myListyIterator = new ListyIterator<string>(input.Skip(1).ToArray()); break;
                        case "Move": Console.WriteLine(myListyIterator.Move()); break;
                        case "Print": Console.WriteLine(myListyIterator.Print()); break;
                        case "PrintAll": Console.WriteLine(string.Join(" ",myListyIterator.PrintAll())); break;
                        case "HasNext": Console.WriteLine(myListyIterator.HasNext()); break;
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
