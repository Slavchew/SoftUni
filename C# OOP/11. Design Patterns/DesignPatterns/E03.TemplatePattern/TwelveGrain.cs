using System;
using System.Collections.Generic;
using System.Text;

namespace E03.TemplatePattern
{
    public class TwelveGrain : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Gathring Ingredients for 12-Grain Bread.");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Baking the 12-Grain Bread. (25 minutes)");
        }
    }
}
