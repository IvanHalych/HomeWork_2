using System;
using System.Collections.Generic;
using System.Text;
using Library.Interface;
using Library.Abstract;

namespace Library.PaymentMethod
{
    public class GiftVoucher : PaymentMethodBase,ISupportDeposit
    {
        List<string> usedGiftCardNumbers;
        public GiftVoucher()
        {
            Name = "GiftVoucher";
            usedGiftCardNumbers = new List<string>();
        }
        public void StartDeposit(decimal amount, string currency)
        {
            RandomError();
            if (amount == 100 || amount == 500 || amount == 1000)
            {
                string GiftCardNumber = EnterConsoleValue.GetGiftCardNumber();
                foreach(string GiftNumber in usedGiftCardNumbers)
                {
                    if(GiftNumber == GiftCardNumber)
                    {
                        Console.WriteLine("This GiftCard was used");
                        return;
                    }
                }
                usedGiftCardNumbers.Add(GiftCardNumber);
                Console.WriteLine($"You’ve deposit {amount} {currency} to your Account from {GiftCardNumber} GiftCard successfully");
            }
            else
            {
                Console.WriteLine("You must enter the correct amount equal to the face value of the certificate(100 / 500 / 1000).");
            } 
        }
    }
}
