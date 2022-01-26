using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Bank
{
    class SavingsAccount : Account
    {
        public SavingsAccount(int id, string firstName, string lastName, long pesel)
           : base(id, firstName, lastName, pesel)
        {
        }

        public void SetInterest(decimal interest)
        {
            Balance += Balance * interest;
        }

        public override string TypeName()
        {
            return "Savings";
        }
    }
}
