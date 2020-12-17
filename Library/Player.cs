using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Player
    {
        int Id;
        string FirstName;
        string LastName;
        public string Email { get; }
        string Password { get; }
        Account Account;

        public Player(string firstName, string lastName, string email, string password,string Currency)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Account = new Account(Currency);
        }
        public bool IsPasswordValid(string password)
        {
            return password == Password;
        }
        public void Deposit(decimal amount, string Currency)
        {
            Account.Deposit(amount, Currency);
        }
        public void Withdraw(decimal amount, string Currency)
        {
            Account.Withdraw(amount, Currency);
        }
    }
}
