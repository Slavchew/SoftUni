using System;
using System.Collections.Generic;
using System.Linq;

namespace Transport
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Truck> trucks = new List<Truck>();
            List<Freight> freights = new List<Freight>();

            try
            {
                ParseTrucksInput(trucks);

                ParseFreightsInput(freights);

                var commands = Console.ReadLine().Split(" ");
                while (commands[0] != "END")
                {
                    var truckName = commands[0];
                    var freightName = commands[1];


                    var truck = trucks.First(t => t.Name == truckName);
                    var freight = freights.First(f => f.Name == freightName);

                    truck.AddFreight(freight);

                    commands = Console.ReadLine().Split(" ");
                }

                Console.WriteLine();

                foreach (var truck in trucks)
                {
                    Console.WriteLine(truck);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private static void ParseTrucksInput(List<Truck> trucks)
        {
            var trucksInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < trucksInput.Length; i++)
            {
                var truckInput = trucksInput[i].Split("=");
                var truckName = truckInput[0];
                var truckCapacity = double.Parse(truckInput[1]);

                Truck truck = new Truck(truckName, truckCapacity);

                trucks.Add(truck);
            }
        }

        private static void ParseFreightsInput(List<Freight> freights)
        {
            var freightsInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < freightsInput.Length; i++)
            {
                var freightInput = freightsInput[i].Split("=");
                var freightName = freightInput[0];
                var freightCapacity = double.Parse(freightInput[1]);

                Freight freight = new Freight(freightName, freightCapacity);

                freights.Add(freight);
            }
        }
    }
}
