using System;
using System.Collections.Generic;
using System.Text;

namespace E03.TemplatePattern
{
    public class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Gathring Ingredients for Whole Wheat Bread.");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Baking the Whole Wheat Bread. (15 minutes)");
        }
    }
}
