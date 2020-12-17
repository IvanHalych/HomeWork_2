using System;
using Library;
namespace Task_1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Account[] accounts = new Account[1_000_000];
            for (int i = 0; i < accounts.Length; i++)
            {
                accounts[i] = new Account("UAH");
            }
            accounts = Account.GetSortedAccounts(accounts);
            Account.GetAccount(accounts[5].Id, accounts);
        }
    }
}
