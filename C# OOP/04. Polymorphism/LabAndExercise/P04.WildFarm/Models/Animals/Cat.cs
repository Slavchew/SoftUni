using System;
using System.Collections.Generic;

using P04.WildFarm.Models.Foods;

namespace P04.WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => 0.30;

        public override ICollection<Type> PreferredFoods =>
            new List<Type>() { typeof(Vegetable), typeof(Meat) };

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
