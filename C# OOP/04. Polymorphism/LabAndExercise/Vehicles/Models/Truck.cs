using System;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCR = 1.6;
        private const double REFUEL_SUCC_COEFF = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + FUEL_CONSUMPTION_INCR;

        public override void Refuel(double amount)
        {
            if (amount > this.TankCapacity)
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.NotEnoughSpaceInTank, amount));
            }
            base.Refuel(amount * REFUEL_SUCC_COEFF);
        }
    }
}
