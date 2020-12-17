using System;
using System.Collections.Generic;
using System.Text;
using Library.Abstract;
using Library.Exceptions;

namespace Library.PaymentMethod
{
    public class Stereobank: Bank
    {
        public Stereobank() 
        {
            Name = "Stereobank";
            AvailableCards = new string[] {"Black", "White", "Iron"};
            limitAmountOfTransactions = 7_000;
            limitOfTransactions = 3_000;
        }
        public override void StartDeposit(decimal amount, string currency)
        {
            RandomError();
            if (Account.ConvertToUAH(amount, currency) > limitOfTransactions)
                throw new LimitExceededException();
            if ((amountOfTransactions + Account.ConvertToUAH(amount, currency)) > limitAmountOfTransactions)
                throw new LimitExceededException();
            base.StartDeposit(amount, currency);
            amountOfTransactions += Account.ConvertToUAH(amount, currency);
        }
        public override void StartWithdrawal(decimal amount, string currency)
        {
            RandomError();
            if (Account.ConvertToUAH(amount, currency) > limitOfTransactions)
                throw new LimitExceededException();
            if ((amountOfTransactions + Account.ConvertToUAH(amount, currency)) > limitAmountOfTransactions)
                throw new LimitExceededException();
            base.StartWithdrawal(amount, currency);
            amountOfTransactions += Account.ConvertToUAH(amount, currency);
        }
    }
}
