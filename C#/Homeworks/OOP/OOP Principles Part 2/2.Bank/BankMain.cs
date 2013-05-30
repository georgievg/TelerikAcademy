using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Bank
{
    class BankMain
    {
        static void Main()
        {
            Accounts[] accs =
            {
                new LoanAccount(5353.43,314.3,Customers.Company),
                new MortgageAccounts(431,43,Customers.Individual),
                new DepositAccounts(432,67,Customers.Company),
            };
            foreach (var acc in accs)
            {
                Console.WriteLine(acc.CalcInterestForPeriod(34));    
            }
        }
    }
}
