using System;

namespace TravelByCar
{
    class Car
    {
        public Car(string model, int fuel, double fuelConsumption)
        {
            Model = model;
            Fuel = fuel;
            FuelConsumption = fuelConsumption;
            Kilometers = 0;
        }

        public string Model { get; set; }
        public double Fuel { get; set; }
        public double FuelConsumption { get; set; }
        public double Kilometers { get; set; }

        public void Drive(double km)
        {
            if (km * FuelConsumption < Fuel)
            {
                this.Fuel -= (km * this.FuelConsumption);
                this.Kilometers += km;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
