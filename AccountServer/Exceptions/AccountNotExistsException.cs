using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountServer.Exceptions
{
    public class AccountNotExistsException : Exception
    {
        public string AccountName { get; set; }

        public AccountNotExistsException(string accountName) : base($"Account {accountName} not exists")
        {
            AccountName = accountName;
        }
    }
}
