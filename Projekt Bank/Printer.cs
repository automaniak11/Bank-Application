using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Bank
{
    class Printer : IPrinter
    {
        public void Print(Account account)
        {
            Console.WriteLine("Account Data: {0}", account.AccountNumber);
            Console.WriteLine("Type: {0}", account.TypeName());
            Console.WriteLine("Balance: {0}", account.GetBalance());
            Console.WriteLine("Full Name: {0}", account.GetFullName());
            Console.WriteLine("PESEL: {0}", account.Pesel);
            Console.WriteLine();
        }
    }
}
