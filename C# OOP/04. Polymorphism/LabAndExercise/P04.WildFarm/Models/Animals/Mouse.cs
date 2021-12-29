using System;
using System.Collections.Generic;
using P04.WildFarm.Models.Foods;

namespace P04.WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier => 0.10;

        public override ICollection<Type> PreferredFoods =>
            new List<Type>() { typeof(Vegetable), typeof(Fruit) };

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
