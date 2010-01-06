using System.Collections.Generic;
using System.Linq;

namespace TryRx
{
    public class AccountRepository
    {
        private readonly IList<Account> _accounts;

        public AccountRepository(IList<Account> accounts)
        {
            _accounts = accounts;
        }

        public Account GetAccount(string accountNumber)
        {
            return _accounts.First(_ => _.Number == accountNumber);
        }
    }
}