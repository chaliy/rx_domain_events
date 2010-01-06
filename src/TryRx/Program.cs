using System;
using System.Linq;
using System.Collections.Generic;

namespace TryRx
{
    class Program
    {
        static void Main(string[] args)
        {
            // Emulate database
            var accounts = new List<Account>
                               {
                                   new Account("First") {CurrentBalance = 300.0m},
                                   new Account("Second") {CurrentBalance = 100.0m},
                               };

            var repository = new AccountRepository(accounts);

            // Setup listeners

            // Log everything...
            Account.TransferMoney
                .Subscribe(t => Console.WriteLine("Log transfer of {0:c} bucks.", t.Amount));
            
            // Notify manager about large transfers
            Account.TransferMoney
                .Where(_ => _.Amount > 100.0m)
                .Subscribe(_ => Console.WriteLine("Notify manager about large transfer."));
            
            // Subscribe money transfer target listener 
            Account.TransferMoney.Subscribe(new TransferMoneyObserver(repository)); // Handle 
            

            // Execute some stuff

            var account = repository.GetAccount("First");

            Console.WriteLine("\r\n************First transfer************\r\n");
            account.SendTransferTo("Second", 125.0m);

            Console.WriteLine("\r\n************Second transfer************\r\n");
            account.SendTransferTo("Second", 25.0m);
        }                     
    }
}
