using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks
{
    class Bricks
    {
        static void Main(string[] args)
        {
            /*
            var bricks = int.Parse(Console.ReadLine());
            var workers = int.Parse(Console.ReadLine());
            var capacity = int.Parse(Console.ReadLine());

            var bricksOnGoing = capacity * workers;
            var numberOfGoing = bricks / bricksOnGoing;

            if (bricks % bricksOnGoing == 0)
            {
                Console.WriteLine(numberOfGoing);
            }
            else
            {
                numberOfGoing += 1;
                Console.WriteLine(numberOfGoing);
            }
            */

            int bricks = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            double course = bricks / (double)(workers * capacity);
            if (workers * capacity >= bricks)
            {
                Console.WriteLine(Math.Ceiling(course));
            }
            else
            {
                Console.WriteLine(course);
            }
        }
    }
}
