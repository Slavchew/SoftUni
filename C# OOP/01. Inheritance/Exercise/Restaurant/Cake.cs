using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const decimal DefaultCakePrice = 5.00m;
        private const double DefaultCakeGrams = 250.0;
        private const double DefaultCakeCalories = 1000.0;
        public Cake(string name) 
            : base(name, DefaultCakePrice, DefaultCakeGrams, DefaultCakeCalories)
        {
        }
    }
}
