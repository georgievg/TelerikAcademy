using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2.Bank
{
    public class MortgageAccounts:Accounts,IWithDrawable
    {
        public MortgageAccounts(double balance, double interestRate, Customers customer)
            : base(balance, interestRate, customer)
        {

        }
        public void WithDrawMoney(double value)
        {
            this.Balance += value;
        }
        public override double CalcInterestForPeriod(int months)
        {
            if (this.Customer == Customers.Individual)
            {
                months = months - 6;
                return this.InterestRate * months;
            }
            else if (this.Customer == Customers.Company)
            {
                double totalInterest = 0;
                if (months <= 12)
                {
                    totalInterest = months * (this.InterestRate / 2);
                    return totalInterest;
                }
                else if (months > 12)
                {
                    totalInterest = 12 * (this.InterestRate / 2);
                    int monthsLeft = months - 12;
                    totalInterest += this.InterestRate * monthsLeft;
                    return totalInterest;
                }
            }
            return 0;
        }
    }
}