using System;
using System.Collections.Generic;
using System.Text;
using Library.Abstract;
using Library.PaymentMethod;
using Library.Interface;

namespace Library
{
    public class PaymentService 
    {
        PaymentMethodBase[] AvailablePaymentMethod;
        public PaymentService()
        {
            AvailablePaymentMethod = new PaymentMethodBase[] { new CreditCard(), new Privet48(), new Stereobank(), new GiftVoucher() };
        }
        public void StartDeposit(decimal amount, string currency)
        {
            Console.WriteLine("" +
                "1.CreditCard\n" +
                "2.Privet48\n" +
                "3.Stereobank\n" +
                "4.GiftVoucher");
            while (true)
            {
                Console.WriteLine("Enter Payment Method");
                string input = Console.ReadLine();
                foreach(PaymentMethodBase method in AvailablePaymentMethod)
                {
                    if(method.GetName() == input )
                    {
                        if (method is ISupportDeposit)
                        {
                            ((ISupportDeposit)method).StartDeposit(amount, currency);
                            return;
                        }
                        
                    }

                }
                Console.WriteLine("Invalid format input");
            }
        }
        public void StartWithdrawal(decimal amount, string currency)
        {
            Console.WriteLine("" +
                "1.CreditCard\n" +
                "2.Privet48\n" +
                "3.Stereobank");
            while (true)
            {
                Console.WriteLine("Enter Payment Method");
                string input = Console.ReadLine();
                foreach (PaymentMethodBase method in AvailablePaymentMethod)
                {
                    if (method.GetName() == input)
                    {
                        if (method is ISupportWithdrawal)
                        {
                            ((ISupportWithdrawal)method).StartWithdrawal(amount, currency);
                            return;
                        }
                    }

                }
                Console.WriteLine("Invalid format input");
            }
        }
    }
}
