using System;
using System.Collections.Generic;
using P04.WildFarm.Models.Foods.Contracts;

namespace P04.WildFarm.Models.Animals.Contracts
{
    public interface IFeedable
    {
        void Feed(IFood food);

        int FoodEaten { get; }

        double WeightMultiplier { get; }

        ICollection<Type> PreferredFoods { get; }
    }
}
