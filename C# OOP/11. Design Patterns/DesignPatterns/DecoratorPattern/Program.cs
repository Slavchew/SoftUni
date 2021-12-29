using System;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IPaymentSystem payment = new PayPalSystem();
        }
    }
}
