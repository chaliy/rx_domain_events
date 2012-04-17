namespace TryComplexRx.Domain.Accounts
{
    using Abstractions;

    public class Account : EntityInContext
    {
        public string Number { get; protected set; }
        public decimal CurrentBalance { get; protected set; }

        internal Account()
        {
        }

        public void Create(string number)
        {            
            Number = number;
            SubmitEvent(new AccountCreated
            {                
                AccountNumber = Number
            });
        }

        public void SendTransferTo(string targetAccountNumber, decimal amount)
        {
            CurrentBalance -= amount;

            SubmitEvent(new MoneyTransferedTo
            {
                Amount = amount,
                AccountNumber = Number,
                TargetAccountNumber = targetAccountNumber
            });
        }

        public void RegisterTransferedFrom(string sourceAccountNumber, decimal amount)
        {
            CurrentBalance += amount;

            SubmitEvent(new MoneyTransferedFrom
            {
                Amount = amount,
                AccountNumber = Number,
                SourceAccountNumber = sourceAccountNumber
            });
        }        
    }
}
