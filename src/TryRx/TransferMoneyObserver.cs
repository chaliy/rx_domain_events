using System;

namespace TryRx
{
    public class TransferMoneyObserver : IObserver<TransferMoney>
    {
        private readonly AccountRepository _repository;

        public TransferMoneyObserver(AccountRepository repository)
        {
            _repository = repository;            
        }

        public void OnNext(TransferMoney value)
        {
            var target = _repository.GetAccount(value.TargetAccountNumber);
            target.ReceiveTransferFrom(value.SourceAccountNumber, value.Amount);
        }

        public void OnError(Exception error)
        {            
        }

        public void OnCompleted()
        {
        }
    }
}
