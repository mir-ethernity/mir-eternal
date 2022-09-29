using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountServer.Exceptions
{
    public class AccountAlreadyRegisteredException : Exception
    {
        public string AccountName { get; set; }

        public AccountAlreadyRegisteredException(string accountName) : base($"Account \"{accountName}\" already registered.")
        {
            AccountName = accountName;
        }
    }
}
