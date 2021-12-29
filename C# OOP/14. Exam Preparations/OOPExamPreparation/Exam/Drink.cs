using System;

public class Drink : Product
{
    private const double maxPercentageMarkup = 200;

    public Drink(string name, int quantity, double deliverPrice, double percentageMarkup) 
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
                throw new ArgumentException("Drink percentage markup cannot be above 200%!");
            }
        }
    }
}
