using System;
using System.Collections.Generic;
using System.Linq;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ");
            var bankAccounts = new Dictionary<int, BankAccount>();
            while (input[0] != "End")
            {
                var command = input[0];
                var id = int.Parse(input[1]);

                if (command == "Create")
                {
                    if (!bankAccounts.ContainsKey(id))
                    {
                        var acc = new BankAccount();
                        acc.Id = id;
                        bankAccounts.Add(id, acc);
                    }
                    else
                    {
                        Console.WriteLine("Account already exists");
                    }
                }
                else if (command == "Deposit")
                {
                    var amount = double.Parse(input[2]);
                    if (!bankAccounts.ContainsKey(id))
                    {
                        Console.WriteLine("Account does not exist");
                    }
                    else
                    {
                        bankAccounts[id].Deposit(amount);
                    }
                }
                else if (command == "Withdraw")
                {
                    var amount = double.Parse(input[2]);
                    if (!bankAccounts.ContainsKey(id))
                    {
                        Console.WriteLine("Account does not exist");
                    }
                    else
                    {
                        if (amount > bankAccounts[id].balance)
                        {
                            Console.WriteLine("Insufficient balance");
                        }
                        else
                        {
                            bankAccounts[id].Withdraw(amount);
                        }
                    }
                }
                else if (command == "Print")
                {
                    if (!bankAccounts.ContainsKey(id))
                    {
                        Console.WriteLine("Account does not exist");
                    }
                    else
                    {
                        Console.WriteLine(bankAccounts[id].ToString());
                    }
                }

                input = Console.ReadLine().Split(" ");
            }
        }
    }
}
