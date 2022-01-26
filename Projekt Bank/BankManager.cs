using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Bank
{
    class BankManager
    {
        private AccountsManager _accountsManager;
        private IPrinter _printer;

        public BankManager()
        {
            _accountsManager = new AccountsManager();
            _printer = new Printer();
        }

        public void Run()
        {
            int action;
            do
            {
                PrintMainMenu();
                action = SelectedAction();

                switch (action)
                {
                    case 1:
                        ListOfAccounts();
                        break;
                    case 2:
                        AddBillingAccount();
                        break;
                    case 3:
                        Console.Clear();
                        AddSavingsAccount();
                        Console.ReadKey();
                        break;
                    case 4:
                        AddMoney();
                        break;
                    case 5:
                        Console.Clear();
                        TakeMoney();
                        Console.ReadKey();
                        break;
                    case 6:
                        ListOfCustomers();
                        break;
                    case 7:
                        ListOfAllAccounts();
                        break;
                    case 8:
                        CloseMonth();
                        break;
                    default:
                        Console.Write("Unknown");
                        break;
                }
            }
            while (action != 0);
        }

        private void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Select action:");
            Console.WriteLine("1 - Client's account list");
            Console.WriteLine("2 - Billing account");
            Console.WriteLine("3 - Saving account");
            Console.WriteLine("4 - Get money into account");
            Console.WriteLine("5 - Take money from account");
            Console.WriteLine("6 - List of clients");
            Console.WriteLine("7 - All accounts");
            Console.WriteLine("8 - End month");
            Console.WriteLine("0 - Done");
        }

        private int SelectedAction()
        {
            Console.Write("Action: ");
            string action = Console.ReadLine();
            if (string.IsNullOrEmpty(action))
            {
                return -1;
            }
            return int.Parse(action);
        }

        private void ListOfAccounts()
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Console.WriteLine();
            Console.WriteLine("Client's account {0} {1} {2}", data.FirstName, data.LastName, data.Pesel);

            foreach (Account account in _accountsManager.GetAllAccountsFor(data.FirstName, data.LastName, data.Pesel))
            {
                _printer.Print(account);
            }
            Console.ReadKey();
        }

        private CustomerData ReadCustomerData()
        {
            string firstName;
            string lastName;
            string pesel;
            Console.WriteLine("Customer data please:");
            Console.Write("First Name: ");
            firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            lastName = Console.ReadLine();
            Console.Write("PESEL: ");
            pesel = Console.ReadLine();

            return new CustomerData(firstName, lastName, pesel);
        }

        private void AddBillingAccount()
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Account billingAccount = _accountsManager.CreateBillingAccount(data.FirstName, data.LastName, data.Pesel);

            Console.WriteLine("Billing account created:");
            _printer.Print(billingAccount);
            Console.ReadKey();
        }

        private void AddSavingsAccount()
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Account savingsAccount = _accountsManager.CreateSavingsAccount(data.FirstName, data.LastName, data.Pesel);

            Console.WriteLine("Savings account created:");
            _printer.Print(savingsAccount);
            Console.ReadKey();
        }

        private void AddMoney()
        {
            string accountNo;
            decimal value;

            Console.WriteLine("Money deposit");
            Console.Write("Account number: ");
            accountNo = Console.ReadLine();
            Console.Write("Sum: ");
            value = decimal.Parse(Console.ReadLine());
            _accountsManager.AddMoney(accountNo, value);

            Account account = _accountsManager.GetAccount(accountNo);
            _printer.Print(account);

            Console.ReadKey();
        }

        private void TakeMoney()
        {
            string accountNo;
            decimal value;

            Console.WriteLine("Money withdraw");
            Console.Write("Account number: ");
            accountNo = Console.ReadLine();
            Console.Write("Sum: ");
            value = decimal.Parse(Console.ReadLine());
            _accountsManager.TakeMoney(accountNo, value);

            Account account = _accountsManager.GetAccount(accountNo);
            _printer.Print(account);

            Console.ReadKey();
        }

        private void ListOfCustomers()
        {
            Console.Clear();
            Console.WriteLine("List of customers:");
            foreach (string customer in _accountsManager.ListOfCustomers())
            {
                Console.WriteLine(customer);
            }
            Console.ReadKey();
        }

        private void ListOfAllAccounts()
        {
            Console.Clear();
            Console.WriteLine("All accounts:");
            foreach (Account account in _accountsManager.GetAllAccounts())
            {
                _printer.Print(account);
            }
            Console.ReadKey();
        }

        private void CloseMonth()
        {
            Console.Clear();
            _accountsManager.CloseMonth();
            Console.WriteLine("Month closed");
            Console.ReadKey();
        }
    }

    class CustomerData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Pesel { get; set; }

        public CustomerData(string firstName, string lastName, string pesel)
        {
            FirstName = firstName;
            LastName = lastName;
            Pesel = long.Parse(pesel);
        }
    }
}
