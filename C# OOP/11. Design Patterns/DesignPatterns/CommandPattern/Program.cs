using CommandPattern.Commands;
using System;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                int value = int.Parse(input[1]);
                ICommand command = null;
                switch (input[0])
                {
                    case "+":
                        command = new PlusCommand(value);
                        break;
                    case "-":
                        command = new MinusCommand(value);
                        break;
                    case "*":
                        command = new MultiplyCommand(value);
                        break;
                    case "undo":
                        calculator.Undo(value);
                        break;
                    case "redo":
                        calculator.Redo(value);
                        break;
                }

                if (command != null)
                {
                    calculator.AddCommand(command);
                }
                Console.WriteLine(calculator.Result);
            }
        }
    }
}
