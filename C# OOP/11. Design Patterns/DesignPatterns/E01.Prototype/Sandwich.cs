using E01.Prototype.Contracts;
using System;

namespace E01.Prototype
{
    public class Sandwich : SandwichPrototype<Sandwich>
    {

        public Sandwich(string bread, string meat, string cheese, string veggies, Drink drink)
        {
            this.Bread = bread;
            this.Meat = meat;
            this.Cheese = cheese;
            this.Veggies = veggies;
            this.Drink = drink;
        }

        public string Bread { get; set; }
        public string Meat { get; set; }
        public string Cheese { get; set; }
        public string Veggies { get; set; }
        public Drink Drink { get; set; }

        public override Sandwich DeepCopy()
        {
            Sandwich sandwich = (Sandwich)this.MemberwiseClone();
            sandwich.Bread = new string(this.Bread);
            sandwich.Meat = new string(this.Meat);
            sandwich.Cheese = new string(this.Cheese);
            sandwich.Veggies = new string(this.Veggies);

            sandwich.Drink = new Drink(this.Drink.Name);

            return sandwich;
        }

        public override Sandwich ShallowCopy()
        {
            return this.MemberwiseClone() as Sandwich;
        }

        public override string ToString()
        {
            return $"{this.Bread}, {this.Meat}, {this.Cheese}, {this.Veggies}, {this.Drink.Name}";
        }
    }
}
