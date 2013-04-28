using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Bank
{
    public abstract class Accounts
    {
        private double balance;
        private double interestRate;
        private Customers customer;

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
        public double InterestRate
        {
            get
            {
                return this.interestRate;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Interest Rate Can not be less than zero");
                }
                this.interestRate = value;
            }
        }
        public Customers Customer
        {
            get
            {
                return this.customer;
            }
            set
            {
                this.customer = value;
            }
        }
        public Accounts(double balance, double interestRate, Customers customer)
        {
            this.Balance = balance;
            this.InterestRate = interestRate;
            this.Customer = customer;
        }

        public abstract double CalcInterestForPeriod(int months);

    }
}
