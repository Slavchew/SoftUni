namespace TestClient
{
    class BankAccount
    {
        public int Id { get; set; }

        public double balance { get; set; }
        public void Deposit(double amount)
        {
            this.balance += amount;
        }
        public void Withdraw(double amount)
        {
            this.balance -= amount;
        }
        public override string ToString()
        {
            return $"Account ID{this.Id}, balance {this.balance:f2}";
        }
    }
}
