using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Dessert : Food
    {
        public Dessert(string name, decimal price, double grams, double calories) 
            : base(name, price, grams)
        {
        }

        public double Calories { get; set; }
    }
}
