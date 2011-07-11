using System;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace TryComplexRx.Domain
{
    public static class Accounts
    {
        private static readonly IDictionary<string, Account> State = new Dictionary<string, Account>();

        public static void Register()
        {
            Env.Events
                .OfType<MoneyTransferedTo>()
                .Subscribe(x =>
                {
                    var account = Get(x.TargetAccountNumber);
                    account.RegisterTransferedFrom(x.AccountNumber, x.Amount);
                });
        }

        public static Account Get(string accountNumer)
        {
            return State[accountNumer];
        }

        public static void Attach(Account account)
        {
            State[account.Number] = account;
        }
    }
}
