using System;

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

        }

        public void OnError(Exception error)
        {            
        }

        public void OnCompleted()
        {
        }
    }
}
