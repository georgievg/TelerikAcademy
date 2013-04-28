using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2.Bank
{
    public class LoanAccount:Accounts,IWithDrawable
    {
        public LoanAccount(double balance, double interestRate, Customers customer)
            : base(balance, interestRate, customer)
        {

        }
        public void WithDrawMoney(double value)
        {
            this.Balance += value;
        }
        public override double CalcInterestForPeriod(int months)
        {
            if (this.Customer == Customers.Company)
            {
                months = months - 2;
            }
            else if (this.Customer == Customers.Individual)
            {
                months = months - 3;
            }
            return this.InterestRate * months;
        }
    }
}