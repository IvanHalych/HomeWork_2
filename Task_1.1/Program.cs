using System;
using Library;
namespace Task_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Account accountEUR = new Account("EUR");
            Account accountUSD = new Account("USD");
            Account accountUAH = new Account("UAH");

            //2
            accountEUR.Deposit(10, "EUR");

            //3
            accountEUR.Withdraw(3, "UAH");

            //4
            accountUAH.Deposit(121, "USD");

            //5
            try
            {
                accountUSD.Withdraw(5, "USD");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //6
            try
            {
                Account accountPLN = new Account("PLN");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //7
            Console.WriteLine("Account with currency {0} has {1} balance", 
                accountEUR.Currency, accountEUR.GetBalance(accountEUR.Currency));
            Console.WriteLine("Account with currency {0} has {1} balance",
                accountUSD.Currency, accountUSD.GetBalance(accountUSD.Currency));
            Console.WriteLine("Account with currency {0} has {1} balance",
                accountUAH.Currency, accountUAH.GetBalance(accountUAH.Currency));


        }
    }
}
