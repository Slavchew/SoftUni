using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPattern
{
    class PayPalSystem : IPaymentSystem
    {
        public void LoanMoney(string from, string to, int amount)
        {
            Console.WriteLine($"Loaned {amount} money from {from} to {to}");
        }

        public void PayMoney(string from, string to, int amount)
        {
            Console.WriteLine($"Paid {amount} money from {from} to {to}");
        }
    }
}
