using System;
using System.Collections.Generic;
using P04.WildFarm.Models.Foods;

namespace P04.WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => 0.25;

        public override ICollection<Type> PreferredFoods => 
            new List<Type>() { typeof(Meat) };

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
