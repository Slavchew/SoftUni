using System;

namespace MyQueue
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CircularQueue<int> queue = new CircularQueue<int>();

            Console.WriteLine(queue.Count);
            Console.WriteLine(queue.Capacity);
            Console.WriteLine("-------------------------------------");

            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(3);
            queue.Enqueue(14);
            queue.Enqueue(99);
            queue.Enqueue(1);

            Console.WriteLine(queue.Count);
            Console.WriteLine(queue.Capacity);
            Console.WriteLine("-------------------------------------");

            queue.Enqueue(1);
            queue.Enqueue(8);
            queue.Enqueue(9);
            queue.Enqueue(54);
            queue.Enqueue(9);
            queue.Enqueue(3);
            queue.Enqueue(1);
            queue.Enqueue(8);
            queue.Enqueue(9);
            queue.Enqueue(54);
            queue.Enqueue(9);
            queue.Enqueue(3);

            Console.WriteLine(queue.Count);
            Console.WriteLine(queue.Capacity);
            Console.WriteLine("-------------------------------------");

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());

            Console.WriteLine("-------------------------------------");
            Console.WriteLine(queue.Count);
            Console.WriteLine(queue.Capacity);
            Console.WriteLine("-------------------------------------");


            var resultArr = queue.ToArray();

            Console.WriteLine(string.Join(", ",resultArr));

        }
    }
}
