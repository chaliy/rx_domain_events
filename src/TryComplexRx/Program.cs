using System;
using TryComplexRx.Domain;

namespace TryComplexRx
{
    using Domain.Accounts;

    class Program
    {
        static void Main(string[] args)
        {
            // Init infrastructure
            // Audit
            //SystemEnv.Events.Subscribe(Console.WriteLine);

            //AccountsModule.Register();
            //const string context = "PROD";

            //var exec = new Execution();
            //var accounts = exec.Resolve<AccountsModule>();
            
            //// Business logic
            //var account1 = accounts.CreateAccount("ACC1");
            //var account2 = accounts.CreateAccount("ACC2");

            //account1.SendTransferTo(account2.Number, 12.0m);

        }
    }
}
