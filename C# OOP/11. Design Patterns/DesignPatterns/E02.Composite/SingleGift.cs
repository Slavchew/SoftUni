using System;
using System.Collections.Generic;
using System.Text;

namespace E02.Composite
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price) 
            : base(name, price)
        {
        }

        public override int CalculateTotalPrice()
        {
            return this.Price;
        }
    }
}
