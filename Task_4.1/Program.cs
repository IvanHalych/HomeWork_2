using System;
using Library.Exceptions;
namespace Task_4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new LimitExceededException();
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine(ex);
            }
            catch (LimitExceededException ex)
            {
                Console.WriteLine(ex);
            }
            catch (PaymentServiceException ex )
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
