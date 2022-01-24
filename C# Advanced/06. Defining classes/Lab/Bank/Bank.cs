using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Bank
    {
        static void Main(string[] args)
        {
            BankAccount acc = new BankAccount();

            acc.Id = 1;
            acc.Balance = 15;

            Console.WriteLine($"Account {acc.Id}, balance {acc.Balance}");
        }
    }
}
