using System;
using System.Collections.Generic;
using System.Text;
using Library.Abstract;
using Library.Exceptions;
namespace Library.PaymentMethod
{
    public class Privet48:Bank
    {

        public Privet48():base()
        {
            Name = "Privet48";
            AvailableCards = new string[]{"Gold", "Platinum"};
            limitAmountOfTransactions = 10_000;
        }
        public override void StartDeposit(decimal amount, string currency)
        {
            RandomError();
            if ((amountOfTransactions + Account.ConvertToUAH(amount, currency)) > limitAmountOfTransactions)
                throw new LimitExceededException();
            base.StartDeposit(amount, currency);
            amountOfTransactions += amount;
        }
        public override void StartWithdrawal(decimal amount, string currency)
        {
            RandomError();
            if ((amountOfTransactions + amount) > limitAmountOfTransactions)
                throw new LimitExceededException();
            base.StartWithdrawal(amount, currency);
            amountOfTransactions += Account.ConvertToUAH(amount, currency);
        }
    }
}
