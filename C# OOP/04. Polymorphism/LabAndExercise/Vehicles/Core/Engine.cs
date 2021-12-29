using System;
using System.Linq;
using Vehicles.Core.Contracts;
using Vehicles.Factories;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly VehicleFactory vehicleFactory;

        public Engine()
        {
            this.vehicleFactory = new VehicleFactory();
        }
        public void Run()
        {
            Vehicle car = this.ProcessVehicleInfo();
            Vehicle truck = this.ProcessVehicleInfo();
            Vehicle bus = this.ProcessVehicleInfo();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string cmdType = cmdArgs[0];
                string vehicleType = cmdArgs[1];
                double arg = double.Parse(cmdArgs[2]);

                try
                {
                    if (cmdType == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Drive(car, arg);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Drive(truck, arg);
                        }
                        else if (vehicleType == "Bus")
                        {
                            this.Drive(bus, arg);
                        }
                    }
                    else if (cmdType == "DriveEmpty")
                    {
                        if (vehicleType == "Car")
                        {
                            this.DriveEmpty(car, arg);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.DriveEmpty(truck, arg);
                        }
                        else if (vehicleType == "Bus")
                        {
                            this.DriveEmpty(bus, arg);
                        }
                    }
                    else if (cmdType == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Refuel(car, arg);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Refuel(truck, arg);
                        }
                        else if (vehicleType == "Bus")
                        {
                            this.Refuel(bus, arg);
                        }
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private void Refuel(Vehicle vehicle, double amount)
        {
            vehicle.Refuel(amount);
        }

        private void Drive(Vehicle vehicle, double kilometers)
        {
            Console.WriteLine(vehicle.Drive(kilometers));
        }

        private void DriveEmpty(Vehicle vehicle, double kilometers)
        {
            Console.WriteLine(vehicle.DriveEmpty(kilometers));
        }

        private Vehicle ProcessVehicleInfo()
        {
            string[] vehicleArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string vehicleType = vehicleArgs[0];
            double fuelQuantity = double.Parse(vehicleArgs[1]);
            double fuelConsumption = double.Parse(vehicleArgs[2]);
            int tankCapacity = int.Parse(vehicleArgs[3]);

            Vehicle currVehicle = this.vehicleFactory.CreateVehicle(vehicleType, fuelQuantity, fuelConsumption, tankCapacity);

            return currVehicle;
        }
    }
}
