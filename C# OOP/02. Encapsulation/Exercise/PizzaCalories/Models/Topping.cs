using System;

using PizzaCalories.Common;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        private string type;
        private double weight;
        private double caloriesModifier = 1;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        public string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException(String.Format(GlobalConstants.InvalidToppingExcMsg, value));
                }
                else if (value.ToLower() == "meat")
                {
                    caloriesModifier *= 1.2;
                }
                else if (value.ToLower() == "veggies")
                {
                    caloriesModifier *= 0.8;
                }
                else if (value.ToLower() == "cheese")
                {
                    caloriesModifier *= 1.1;
                }
                else if (value.ToLower() == "sauce")
                {
                    caloriesModifier *= 0.9;
                }
                this.type = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException(String.Format(GlobalConstants.InvalidDoughWeightExcMsg,
                        this.type, MinWeight, MaxWeight));
                }
                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            double calories = 2 * this.weight * this.caloriesModifier;
            return calories;
        }
    }
}
