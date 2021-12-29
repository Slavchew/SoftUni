using System;

using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDriveable, IRefuelable
    {
        private const string SUCC_DRIVED_MSG = "{0} travelled {1} km";

        protected Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            if (fuelQuantity > TankCapacity)
            {
                this.FuelQuantity = 0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }

        public double TankCapacity { get; set; }

        public virtual double FuelConsumption { get; }


        public string Drive(double amount)
        {
            double fuelNeeded = amount * this.FuelConsumption;

            if (this.FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.NotEnoughFuel, this.GetType().Name));
            }

            this.FuelQuantity -= fuelNeeded;

            return String.Format(SUCC_DRIVED_MSG, this.GetType().Name, amount);
        }

        public virtual void Refuel(double amount)
        {
            if (amount > this.TankCapacity)
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.NotEnoughSpaceInTank, amount));
            }
            else if (amount <= 0)
            {
                throw new InvalidOperationException
                    (ExceptionMessages.NegativeFuel);
            }
            this.FuelQuantity += amount;
        }

        public string DriveEmpty(double kilometers)
        {
            if (this.GetType().Name != "Bus")
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.InvalidVehicleType));
            }

            return this.Drive(kilometers);
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }

    }
}
