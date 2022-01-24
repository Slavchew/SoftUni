using System;

namespace LinkStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            LinkedStack<int> stack = new LinkedStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            var resultArr = stack.ToArray();

            Console.WriteLine(string.Join(", ",resultArr));

        }
    }
}
