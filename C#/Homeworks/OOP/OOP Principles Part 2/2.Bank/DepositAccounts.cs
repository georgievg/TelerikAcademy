using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2.Bank
{
    public class DepositAccounts : Accounts,IDepositable,IWithDrawable
    {
        public DepositAccounts(double balance, double interestRate, Customers customer)
            : base(balance, interestRate, customer)
        {

        }
        public void DepositMoney(double value)
        {
            this.Balance += value;
        }
        public void WithDrawMoney(double value)
        {
            this.Balance -= value;
        }
        public override double CalcInterestForPeriod(int months)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }
            return this.InterestRate * months;
        }
    }
}