using System;
using System.Collections.Generic;
using System.Text;
using Library.Interface;
using Library.Abstract;

namespace Library.Abstract
{
    public abstract class Bank : PaymentMethodBase, ISupportDeposit, ISupportWithdrawal
    {
        protected decimal amountOfTransactions;
        protected decimal limitAmountOfTransactions;
        protected string[] AvailableCards;
        protected Bank()
        {
            amountOfTransactions = 0;
        }
        public virtual void StartDeposit(decimal amount, string currency)
        {
            Console.WriteLine($"Welcome, dear client, to the online bank {Name}!");
            Console.WriteLine("Please, enter your login");
            string login = Console.ReadLine();
            Console.WriteLine("Please, enter your passwor");
            Console.ReadLine();
            Console.WriteLine($"Hello Mr {login}. Pick a card to proceed the transaction");
            for(int i=0;i < AvailableCards.Length; i++)
            {
                Console.WriteLine($"{i}. {AvailableCards[i]}");
            }
            string card = EnterConsoleValue.GetCreditCardInBank("Enter Bank Card",AvailableCards);
            Console.WriteLine($"You’ve withdraw {amount} {currency} from your {card} card successfully");
        }   
        public virtual void StartWithdrawal(decimal amount, string currency)
        {

            Console.WriteLine($"Welcome, dear client, to the online bank {Name}!");
            Console.WriteLine("Please, enter your login");
            string login = Console.ReadLine();
            Console.WriteLine("Please, enter your passwor");
            Console.WriteLine($"Hello Mr {login}. Pick a card to proceed the transaction");
            for (int i = 0; i < AvailableCards.Length; i++)
            {
                Console.WriteLine($"{i}. {AvailableCards[i]}");
            }
            string card = EnterConsoleValue.GetCreditCardInBank("Enter Bank Card", AvailableCards);
            Console.WriteLine("You’ve deposit  {amount} {currency} from your {card[n]} card successfully", amount, currency, card);
        }
    }
}
