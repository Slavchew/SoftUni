using System;
using System.Linq;

namespace EnduranceRally
{
    class EnduranceRally
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(' ').ToList();
            var track = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            var checkpoints = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            for (int i = 0; i < names.Count; i++)
            {
                var fuel = 0.0;
                int startFuel = names[i][0];
                fuel += startFuel;
                var finishIndex = 0;
                for (int j = 0; j < track.Count; j++)
                {
                    if (checkpoints.Contains(j))
                    {
                        if (fuel < 0)
                        {
                            finishIndex = j - 1;
                            break;
                        }
                        fuel += track[j];
                    }
                    else
                    {
                        fuel -= track[j];
                        if (fuel < 0)
                        {
                            finishIndex = j;
                            break;
                        }
                    }
                }

                if (fuel > 0)
                    Console.WriteLine($"{names[i]} - fuel left {fuel:f2}");
                else
                    Console.WriteLine($"{names[i]} - reached {finishIndex}");
            }
        }
    }
}
