namespace TryComplexRx.Domain
{
    public class Account
    {
        public string Number { get; protected set; }
        public decimal CurrentBalance { get; protected set; }

        protected Account()
        {
        }

        public void SendTransferTo(string targetAccountNumber, decimal amount)
        {
            CurrentBalance -= amount;

            Env.Events.OnNext(new MoneyTransferedTo
            {
                Amount = amount,
                AccountNumber = Number,
                TargetAccountNumber = targetAccountNumber
            });
        }

        public void RegisterTransferedFrom(string sourceAccountNumber, decimal amount)
        {
            CurrentBalance += amount;

            Env.Events.OnNext(new MoneyTransferedFrom
            {
                Amount = amount,
                AccountNumber = Number,
                SourceAccountNumber = sourceAccountNumber
            });
        }

        public static Account Create(string number)
        {
            var account = new Account { Number = number };            
            Env.Events.OnNext(new AccountCreated { AccountNumber = number });
            Accounts.Attach(account);
            return account;
        }
        
    }
}
