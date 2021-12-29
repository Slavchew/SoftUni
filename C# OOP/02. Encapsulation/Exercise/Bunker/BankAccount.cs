using System;
using System.Collections.Generic;
using System.Text;

namespace Bunker
{
    class BankAccount
    {
        private int id;
        private double balance = 0;
        public BankAccount(int id)
        {
            this.Id = id;
            this.Balance = balance;
        }
        public int Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                this.id = value;
            }
        }
        public double Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = value;
            }
        }

        public void Deposit(double amount)
        {
            this.Balance += amount; 
        }

        public void Withdraw(double amount)
        {
            if (this.Balance <= amount)
            {
                this.Balance -= amount;
            }
            else
            {

            }
        }
    }
}
