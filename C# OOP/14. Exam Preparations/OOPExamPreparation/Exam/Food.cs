using System;

public class Food : Product
{
    private const double maxPercentageMarkup = 100;

    public Food(string name, int quantity, double deliverPrice, double percentageMarkup) 
        : base(name, quantity, deliverPrice, percentageMarkup)
    {
    }

    public override double PercentageMarkup 
    {
        get { return base.PercentageMarkup; }
        protected set
        {
            base.PercentageMarkup = value;
            if (value > maxPercentageMarkup)
            {
                throw new ArgumentException("Food percentage markup cannot be above 100%!");
            }
        }
    }
}