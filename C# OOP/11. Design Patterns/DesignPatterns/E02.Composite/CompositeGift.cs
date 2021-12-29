using System;
using System.Collections.Generic;
using System.Text;

namespace E02.Composite
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> gifts;

        public CompositeGift(string name, int price) 
            : base(name, price)
        {
            this.gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            this.gifts.Add(gift);
        }

        public bool Remove(GiftBase gift)
        {
            return this.gifts.Remove(gift);
        }

        public override int CalculateTotalPrice()
        {
            var totalPrice = 0;

            foreach (var gift in gifts)
            {
                totalPrice += gift.CalculateTotalPrice();
            }

            return totalPrice;
        }
    }
}
