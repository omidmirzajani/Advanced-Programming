using System;

namespace A9Tests
{
    public class Account
    {
        public int Balance;
        


        public Account(int balance)
        {
            if (balance >= 0)
                this.Balance = balance;
            else
            {
                this.Balance = 0;
                System.Console.WriteLine("Initial balance is invalid. Setting balance to 0.");
            }
        }
        public void Credit(int amount)
        {            
            if (amount>=0)
                this.Balance += amount;
            else
            {
                throw new ArgumentException("Credit amount must be positive");
            }
            
        }

        public bool Debit(int amount)
        {
            if (this.Balance >= amount)
            {
                this.Balance -= amount;
                return true;
            }
            else
            {
                Console.WriteLine("Debit amount exceeded account balance.");
            }
            return false;
        }
    }
}