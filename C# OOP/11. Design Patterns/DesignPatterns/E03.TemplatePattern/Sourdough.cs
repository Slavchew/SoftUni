using System;
using System.Collections.Generic;
using System.Text;

namespace E03.TemplatePattern
{
    public class Sourdough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Gathring Ingredients for Sourdough Bread.");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Baking the Sourdough Bread. (20 minutes)");
        }
    }
}
