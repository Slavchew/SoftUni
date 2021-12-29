using System;
using System.Collections.Generic;
using PizzaCalories.Common;

namespace PizzaCalories.Models
{
    public class Pizza
    {
        private const int NameMaxLength = 15;
        private const int MaxNumberOfToppings = 10;

        private string name;
        private readonly ICollection<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException(String.Format(GlobalConstants.InvalidPizzaNameExcMsg, NameMaxLength));
                }
                this.name = value;
            }
        }
        public Dough Dough { get; set; }

        public double Calories
        {
            get { return this.CalculatePizzaCalories(); }
        }
        public void AddTopping(Topping topping)
        {
            this.toppings.Add(topping);

            if (this.toppings.Count > MaxNumberOfToppings)
            {
                throw new ArgumentException(String.Format(GlobalConstants.InvalidNumberOfToppings, MaxNumberOfToppings));
            }
        }
        public double CalculatePizzaCalories()
        {
            double totalCalories = this.Dough.CalculateCalories();
            foreach (Topping topping in this.toppings)
            {
                totalCalories += topping.CalculateCalories();
            }
            return totalCalories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Calories:F2} Calories.";
        }
    }
}
