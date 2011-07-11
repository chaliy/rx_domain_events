namespace TryComplexRx.Domain
{
    public class AccountCreated : IAccountEvent
    {
        public string AccountNumber { get; set; }

        public override string ToString()
        {
            return string.Format("Account {0} created.", AccountNumber);
        }
    }
}
