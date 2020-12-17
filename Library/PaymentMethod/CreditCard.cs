using System;
using System.Collections.Generic;
using System.Text;
using Library.Interface;
using Library.Abstract;
using Library.Exceptions;

namespace Library.PaymentMethod
{
    public class CreditCard :PaymentMethodBase, ISupportDeposit, ISupportWithdrawal
    {
        public CreditCard()
        {
            Name = "CreditCard";
            limitOfTransactions = 3000;
        }
        public void StartDeposit(decimal amount, string currency)
        {
            RandomError();
            if (Account.ConvertToUAH(amount, currency) > limitOfTransactions)
                throw new LimitExceededException();
            string NumberCredirCard = EnterConsoleValue.GetNumberCard("Enter Number Credir Card");
            string ExpiryDate = EnterConsoleValue.GetExpiryDate("Enter Expiry Date");
            string CVV = EnterConsoleValue.GetCVV("Enter CVV");
            Console.WriteLine($"You’ve withdraw {amount} {currency} from your {NumberCredirCard} card successfully");
        }

        public void StartWithdrawal(decimal amount, string currency)
        {
            RandomError();
            if (Account.ConvertToUAH(amount, currency) > 3000)
                throw new LimitExceededException();
            string NumberCredirCard = EnterConsoleValue.GetNumberCard("Enter Number Credir Card");
            Console.WriteLine($"You’ve deposit {amount} {currency} to your {NumberCredirCard} card successfully");
        }

    }
}
