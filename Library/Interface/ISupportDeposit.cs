using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Interface
{
    interface ISupportDeposit
    {
        void StartDeposit(decimal amount, string currency);
    }
}
