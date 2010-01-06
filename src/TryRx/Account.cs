using System;
using System.Collections.Generic;

namespace TryRx
{
    public class Account
    {
        // Events
        internal static readonly Subject<TransferMoney> TransferMoneySubj
            = new Subject<TransferMoney>();
        public static IObservable<TransferMoney> TransferMoney
        {
            get { return TransferMoneySubj; }
        }

        // Identifer
        private readonly string _number;
        public string Number { get { return _number; } }

        // State
        public decimal CurrentBalance { get; internal set; }

        public Account(string number)
        {
            _number = number;
        }

        public void Withdrawal(decimal amount)
        {
            if (CurrentBalance - amount < 0)
                throw new ApplicationException("Not enough money.");

            CurrentBalance -= amount;
        }

        public void Deposite(decimal amount)
        {
            CurrentBalance += amount;
        }

        public void ReceiveTransferFrom(string sourceAccountNumber, decimal amount)
        {
            Deposite(amount);
        }

        public void SendTransferTo(string targetAccountNumber, decimal amount)
        {
            Withdrawal(amount);

            TransferMoneySubj.OnNext(new TransferMoney
             {
                 Amount = amount,
                 SourceAccountNumber = _number,
                 TargetAccountNumber = targetAccountNumber
             });
        }
    }
}