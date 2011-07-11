using TryComplexRx.Abstractions;

namespace TryComplexRx.Domain
{
    public class AccountCreated : EventInContext, IAccountEvent
    {
        public string AccountNumber { get; set; }

        public override string ToString()
        {
            return string.Format("Account {0} created.", AccountNumber);
        }        
    }
}
