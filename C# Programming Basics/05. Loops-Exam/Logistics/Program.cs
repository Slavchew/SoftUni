using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            var loads = int.Parse(Console.ReadLine());

            var microbusTons = 0.0;
            var truckTons = 0.0;
            var trainTons = 0.0;

            for (int i = 0; i < loads; i++)
            {
                var tons = int.Parse(Console.ReadLine());

                if (tons <= 3)
                {
                    microbusTons += tons;
                }
                else if (tons >3 && tons <= 11)
                {
                    truckTons += tons;
                }
                else
                {
                    trainTons += tons;
                }

            }

            var sumOfTons = microbusTons + truckTons + trainTons;

            var microbusProcentage = microbusTons / sumOfTons * 100;
            var truckProcentage = truckTons / sumOfTons * 100;
            var trainProcentage = trainTons / sumOfTons * 100;

            var averagePrice = (microbusTons * 200 + truckTons * 175 + trainTons * 120) / sumOfTons;

            Console.WriteLine("{0:f2}",averagePrice);
            Console.WriteLine("{0:f2}%", microbusProcentage);
            Console.WriteLine("{0:f2}%", truckProcentage);
            Console.WriteLine("{0:f2}%", trainProcentage);

        }
    }
}
