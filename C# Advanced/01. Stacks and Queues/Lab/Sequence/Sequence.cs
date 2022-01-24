using System;
using System.Collections.Generic;

namespace Sequence
{
    class Sequence
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            int n = int.Parse(Console.ReadLine());
            //int p = int.Parse(Console.ReadLine());

            queue.Enqueue(n);

            int index = 1;

            for (int i = 1; i <= 50; i++)
            {
                int currNum = queue.Dequeue();
                Console.WriteLine(currNum);
                queue.Enqueue(currNum + 1);
                queue.Enqueue(currNum * 2);
            }


            /*
            while (queue.Count > 0)
            {
                int currNum = queue.Dequeue();
                if (currNum == p)
                {
                    Console.WriteLine(index);
                    break;
                }
                else
                {
                    queue.Enqueue(currNum + 1);
                    queue.Enqueue(currNum * 2);
                    index += 1;
                }
            }
            */
        }
    }
}
