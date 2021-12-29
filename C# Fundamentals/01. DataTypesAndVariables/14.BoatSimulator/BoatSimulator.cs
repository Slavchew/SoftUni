using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.BoatSimulator
{
    class BoatSimulator
    {
        static void Main(string[] args)
        {
            char firstBoat = char.Parse(Console.ReadLine());
            char secondBoat = char.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());
            int road = 50;
            int firstBoatRoad = 0;
            int secondBoatRoad = 0;
            for (int i = 1; i <= n; i++)
            {
                string speed = Console.ReadLine();
                if (firstBoatRoad >= 50 || secondBoatRoad >= 50)
                {
                    break;
                }
                else
                {
                    if (speed == "UPGRADE")
                    {
                        firstBoat = (char)(3 + firstBoat);
                        secondBoat = (char)(3 + secondBoat);
                    }
                    else if (i % 2 == 1)
                    {
                        firstBoatRoad += speed.Length;
                    }
                    else if (i % 2 == 0)
                    {
                        secondBoatRoad += speed.Length;
                    }
                }
            }
            if (firstBoatRoad >= 50 || firstBoatRoad > secondBoat)
            {
                Console.WriteLine(firstBoat);
            }
            else if (secondBoatRoad >= 50 || secondBoat > firstBoatRoad)
            {
                Console.WriteLine(secondBoat);
            }
        }
    }
}
