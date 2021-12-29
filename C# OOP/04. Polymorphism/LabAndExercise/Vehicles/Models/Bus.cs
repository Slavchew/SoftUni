using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCR = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override double FuelConsumption => base.FuelConsumption + FUEL_CONSUMPTION_INCR;
    }
}
