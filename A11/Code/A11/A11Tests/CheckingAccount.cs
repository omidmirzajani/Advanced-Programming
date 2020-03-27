using System;
namespace A9Tests
{
    public class CheckingAccount:Account
    {        
        private int transactionFee;

        public CheckingAccount(int balance, int transactionFee):base(balance)
        {            
            this.transactionFee = transactionFee;
        }
        public void Credit(int amount)
        {
            if (amount >= 0)
            {
                this.Balance -= this.transactionFee;
                this.Balance += amount;
            }
            else
                throw new ArgumentException("Credit amount must be positive");
            
        }
        public bool Debit(int amount)
        {
            if (this.Balance >= amount + transactionFee) 
            {
                this.Balance -= amount;
                this.Balance -= transactionFee;

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