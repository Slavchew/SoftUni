using System;

namespace MyStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ArrayStack<int> arrayStack = new ArrayStack<int>();

            Console.WriteLine(arrayStack.Count);
            Console.WriteLine(arrayStack.Capacity);
            Console.WriteLine("-------------------------------------");

            arrayStack.Push(5);
            arrayStack.Push(6);
            arrayStack.Push(3);
            arrayStack.Push(14);
            arrayStack.Push(99);
            arrayStack.Push(1);

            Console.WriteLine(arrayStack.Count);
            Console.WriteLine(arrayStack.Capacity);
            Console.WriteLine("-------------------------------------");

            arrayStack.Push(1);
            arrayStack.Push(8);
            arrayStack.Push(9);
            arrayStack.Push(54);
            arrayStack.Push(9);
            arrayStack.Push(3);
            arrayStack.Push(1);
            arrayStack.Push(8);
            arrayStack.Push(9);
            arrayStack.Push(54);
            arrayStack.Push(9);
            arrayStack.Push(3);

            Console.WriteLine(arrayStack.Count);
            Console.WriteLine(arrayStack.Capacity);
            Console.WriteLine("-------------------------------------");

            Console.WriteLine(arrayStack.Pop());
            Console.WriteLine(arrayStack.Pop());
            Console.WriteLine(arrayStack.Pop());
            Console.WriteLine(arrayStack.Pop());

            Console.WriteLine("-------------------------------------");
            Console.WriteLine(arrayStack.Count);
            Console.WriteLine(arrayStack.Capacity);
            Console.WriteLine("-------------------------------------");


            var resultArr = arrayStack.ToArray();

            Console.WriteLine(string.Join(", ", resultArr));

        }
    }
}
