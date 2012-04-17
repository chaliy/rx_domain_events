﻿namespace TryComplexRx.Domain.Accounts
{    
    public class MoneyTransferedFrom : IAccountEvent
    {
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string SourceAccountNumber { get; set; }

        public override string ToString()
        {
            return string.Format("{0} transferred to account {1} created from account {2}.",
                Amount, AccountNumber, SourceAccountNumber);
        }
    }
}