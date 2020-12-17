using System;
using System.Collections.Generic;
using System.Text;
using Library.Exceptions;

namespace Library.Abstract
{
    public abstract class PaymentMethodBase
    {
        protected string Name;
        protected decimal limitOfTransactions;
        public string GetName()
        {
            return Name;
        }
        protected void RandomError()
        {
            if (new Random().Next(100) < 2)
                throw new PaymentServiceException();
        }
       
    }
}
