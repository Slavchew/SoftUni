using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Change_Tiles
{
    class Program
    {
        static void Main(string[] args)
        {

            var money = double.Parse(Console.ReadLine());
            var floorWidth = double.Parse(Console.ReadLine());
            var floorLength = double.Parse(Console.ReadLine());
            var tileSide = double.Parse(Console.ReadLine());
            var tileHeight = double.Parse(Console.ReadLine());
            var tilePrice = double.Parse(Console.ReadLine());
            var WorkerPrice = double.Parse(Console.ReadLine());

            var bathArea = floorWidth * floorLength;
            var tileArea = tileSide * tileHeight / 2;

            var numberOfTiles = Math.Ceiling(bathArea / tileArea) + 5;

            var sum = numberOfTiles * tilePrice + WorkerPrice;

            if (sum <= money)
            {
                Console.WriteLine("{0:f2} lv left.",money - sum);
            }
            else
            {
                Console.WriteLine("You'll need {0:f2} lv more.",sum - money);
            }

        }
    }
}
