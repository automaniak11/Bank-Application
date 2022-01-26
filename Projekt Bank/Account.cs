using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Bank
{
    abstract class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; protected set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Pesel { get; set; }

        public Account(int id, string firstName, string lastName, long pesel)
        {
            Id = id;
            AccountNumber = generateAccountNumber(id);
            Balance = 0.0M;
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
        }

        public abstract string TypeName();

        public string GetFullName()
        {
            string fullName = string.Format("{0} {1}", FirstName, LastName);

            return fullName;
        }

        public string GetBalance()
        {
            return string.Format("{0}zł", Balance);
        }

        public void ChangeBalance(decimal value)
        {
            Balance += value;
        }

        private string generateAccountNumber(int id)
        {
            var accountNumber = string.Format("63{0:D10}", id);

            return accountNumber;
        }
    }
}
