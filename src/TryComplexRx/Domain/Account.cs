using TryComplexRx.Abstractions;

namespace TryComplexRx.Domain
{
    public class Account : EntityInContext
    {
        public string Number { get; protected set; }
        public decimal CurrentBalance { get; protected set; }

        protected Account()
        {
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

        public static Account Create(string context, string number)
        {
            var account = new Account { Context = context, Number = number };            
            Env.Events.OnNext(new AccountCreated { Context = context, AccountNumber = number });
            Accounts.Attach(account);
            return account;
        }
        
    }
}
