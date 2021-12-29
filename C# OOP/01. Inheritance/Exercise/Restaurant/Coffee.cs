using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double DefaultCoffeeMililiters = 50;
        private const decimal DefaultCoffeePrice = 3.50m;
        public Coffee(string name, double caffeine) 
            : base(name, DefaultCoffeePrice, DefaultCoffeeMililiters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
