using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public class BankAccount
    {
        public BankAccount(decimal amount)
        {
            Amount = amount;
        }

        public decimal Amount { get; set; }
    }
}
