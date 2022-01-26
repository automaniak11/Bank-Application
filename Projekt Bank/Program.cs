using Projekt_Bank;
using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            BankManager bankManager = new BankManager();
            bankManager.Run();

            /*
             #Features
            1- Client's account list
            2- Billing account
            3- Saving account
            4- Get money into account
            5- Take money from account
            6- List of clients
            7- All accounts
            8- End month
            9 - Done
            #TODO
            Create interface IPrinted with method which
            doesn't send back any data named Print and oject of type Account
            - Printer(implements IPrinter)
            - Abstract class based account with those fields:
            * Id, AccountNumber, Balance, FirstName, LastName, Pesel 
            * And constructor which is gonna take and configre values of those vields
            * - Abstract method which returns string TypeName()
            * - Methods returning string: GetFullName and GetBalance,
            * - Method ChangeBalance takes amount wihch has to change acc balance
            * - GenerateAccountNumber which takes account ID
            * - Savings Account - child of Account, has methods: SetInterest and TypeName
            * - Billing Account - child of Account, has TakeCharche and TypeName
            * - AccountsManager - Takes list of opened accounts in one place:
            * *CreateBillingAccount, CreateSavingAccount, GetAllAccounts, GetAccountsFor, GetAccount, ListOfCustomers,
            *  CloseMonth(takes 5PLN for having an account), AddMoney, Deposit, Withdraw, GenerateId
            *  
            * *BankManager - This class has all logics staying behind showing menu and running all program's functions
            * Create methods: Run(is responsible for management of our program), PrintMainMenu,
            * ListOfAccounts, CustomerData, AddBillingAccount, AddSavingsAccount.
            */
        }
    }
}
