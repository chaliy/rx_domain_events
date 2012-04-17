namespace TryComplexRx.Domain.Accounts
{
    using System;
    using System.Collections.Generic;
    using System.Reactive.Linq;
    
    public class AccountsModule
    {
        readonly Execution execution;
        static readonly IDictionary<string, Account> State = new Dictionary<string, Account>();
        
        public AccountsModule(Execution execution)
        {
            this.execution = execution;
            this.execution.Events
                .OfType<MoneyTransferedTo>()
                .Subscribe(x =>
                {
                    var account = Get(x.TargetAccountNumber);
                    account.RegisterTransferedFrom(x.AccountNumber, x.Amount);
                });
        }
        
        public Account Get(string accountNumer)
        {
            return State[accountNumer];
        }
        
        public Account CreateAccount(string number)
        {
            var acc = new Account();            
            execution.Register(acc.Events);

            acc.Create(number);

            State[number] = acc;

            return acc;
        }
    }
}
