using System;
using System.Collections.Generic;
using System.Linq;

namespace OverlapOfRectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ");
            var n = int.Parse(input[0]);
            var m = int.Parse(input[1]);
            List<Rectangle> rectangles = new List<Rectangle>();
            for (int i = 0; i < n; i++)
            {
                var rectangleInput = Console.ReadLine().Split(" ");
                var id = rectangleInput[0];
                var width = int.Parse(rectangleInput[1]);
                var height = int.Parse(rectangleInput[2]);
                var leftPoint = int.Parse(rectangleInput[3]);
                var topPoint = int.Parse(rectangleInput[4]);
                rectangles.Add(new Rectangle(id, width, height, leftPoint, topPoint));
            }
            for (int i = 0; i < m; i++)
            {
                var iDs = Console.ReadLine().Split(" ");
                var firstID = iDs[0];
                var secondID = iDs[1];

                var firstRec = rectangles.Where(x => x.Id == firstID).First();
                var secondRec = rectangles.Where(x => x.Id == secondID).First();

                if (firstRec.Width == secondRec.Width && firstRec.Height == secondRec.Height && firstRec.LeftPoint == secondRec.LeftPoint && firstRec.TopPoint == secondRec.TopPoint)
                {
                    Console.WriteLine("true");
                }
                else
                    Console.WriteLine("false");
            }

        }
    }
}
