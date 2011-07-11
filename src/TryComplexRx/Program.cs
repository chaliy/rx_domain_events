﻿using System;
using TryComplexRx.Domain;
using TryComplexRx.Infrastructure;

namespace TryComplexRx
{
    class Program
    {
        static void Main(string[] args)
        {
            // Init infrastructure
            // Unit of Work
            var uow = new UnitOfWork();
            Env.Events.Subscribe(uow);
            // Audit
            Env.Events.Subscribe(Console.WriteLine);

            Accounts.Register();
            const string context = "PROD";

            // Business logic
            var account1 = Account.Create(context, "ACC1");
            var account2 = Account.Create(context, "ACC2");

            account1.SendTransferTo(account2.Number, 12.0m);


            // Submit operation to database
            uow.Commit();
        }
    }
}