namespace TryComplexRx.Domain
{
    public class MoneyTransferedTo : IAccountEvent
    {
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }        
        public string TargetAccountNumber { get; set; }

        public override string ToString()
        {
            return string.Format("{0} transferred from account {1} created to account {2}.", 
                Amount, AccountNumber, TargetAccountNumber);
        }
    }
}