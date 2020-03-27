using System;

namespace A9Tests
{
    public class SavingsAccount: Account
    {
        
        public double InterestRate;        
        public SavingsAccount(int balance,double interestRate):base(balance)
        {
            
            this.InterestRate = interestRate;
        }

        public double CalculateInterest()
        {
            return this.Balance * this.InterestRate;
        }
    }
}