using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPattern
{
    class PaymanSystemDecorator : IPaymentSystem
    {
        private IPaymentSystem paymentSystem;

        public PaymanSystemDecorator(IPaymentSystem paymentSystem)
        {
            this.paymentSystem = paymentSystem;
        }

        public void LoanMoney(string from, string to, int amount)
        {
            paymentSystem.LoanMoney(from, to, amount);
        }

        public void PayMoney(string from, string to, int amount)
        {
            paymentSystem.PayMoney(from, to, amount);
        }
    }
}
