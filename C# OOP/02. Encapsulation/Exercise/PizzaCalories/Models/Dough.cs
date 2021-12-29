using System;

using PizzaCalories.Common;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;

        private string flour;
        private string bakingTechnique;
        private double weight;
        private double caloriesModifier = 1;
        public Dough(string flour, string bakingTechnique, double weight)
        {
            this.Flour = flour;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string Flour
        {
            get
            {
                return this.flour;
            }
            private set
            {
                if (value != "white" && value != "wholegrain")
                {
                    throw new ArgumentException(GlobalConstants.InvalidDoughExcMsg);
                }
                else if (value == "white")
                {
                    caloriesModifier *= 1.5;
                }
                else if (value == "wholegrain")
                {
                    caloriesModifier *= 1.0;
                }
                this.flour = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if (value != "crispy" && value != "chewy" && value != "homemade")
                {
                    throw new ArgumentException(GlobalConstants.InvalidDoughExcMsg);
                }
                else if (value == "crispy")
                {
                    caloriesModifier *= 0.9;
                }
                else if (value == "chewy")
                {
                    caloriesModifier *= 1.1;
                }
                else if (value == "homemade")
                {
                    caloriesModifier *= 1.0;
                }
                this.bakingTechnique = value;
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
                        nameof(Dough), MinWeight, MaxWeight));
                }
                this.weight = value;
            }
        }

        //private double CaloriesModifier => this.caloriesModifier;

        public double CalculateCalories()
        {
            double calories = 2 * this.weight * this.caloriesModifier;
            return calories;
        }
    }
}
