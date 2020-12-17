using System;
using Library;
using Library.Exceptions;
namespace Task_4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PaymentService paymentService = new PaymentService();

                //paymentService.StartDeposit(200, "USD");

                //paymentService.StartDeposit(500, "EUR");

                //paymentService.StartDeposit(400, "EUR");

                //paymentService.StartDeposit(100, "EUR");
                paymentService.StartDeposit(500, "EUR");
                paymentService.StartDeposit(500, "EUR");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine(ex);
            }
            catch (LimitExceededException ex)
            {
                Console.WriteLine(ex);
            }
            catch (PaymentServiceException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
