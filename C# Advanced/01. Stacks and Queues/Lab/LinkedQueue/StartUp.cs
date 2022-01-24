using System;

namespace LinkedQueue
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomQueue<string> queue = new CustomQueue<string>();

            queue.Enqueue("Hey");
            queue.Enqueue("how");
            queue.Enqueue("are");
            queue.Enqueue("you");

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}
