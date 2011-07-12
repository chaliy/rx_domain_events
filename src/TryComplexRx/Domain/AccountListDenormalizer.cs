using System;
using TryComplexRx.Infrastructure;

namespace TryComplexRx.Domain
{
    public class AccountListDenormalizer : IObserver<object>
    {
        public class AccountListItem
        {
            public string Number { get; set; }
            public decimal CurrentBalance { get; set; }
            public DateTime LastUpdate { get; set; }
            public string Context { get; set; }
        }        
        public void OnNext(object value)
        {
            _.Match(value,
                _.Is<AccountCreated>(x =>
                {
                    Views.Store(x.Context, x.AccountNumber, new AccountListItem
                    {
                        Context = x.Context,
                        Number = x.AccountNumber,
                        LastUpdate = DateTime.UtcNow,
                        CurrentBalance = 0
                    });
                }),
                _.Is<MoneyTransferedFrom>(x =>
                {
                    Views.Store(x.Context, x.AccountNumber, new AccountListItem
                    {
                        Context = x.Context,
                        Number = x.AccountNumber,
                        LastUpdate = DateTime.UtcNow,
                        CurrentBalance = 0
                    });
                }));
        }

        public void OnError(Exception error)
        {            
        }

        public void OnCompleted()
        {
        }
    }    
}