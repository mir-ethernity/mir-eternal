using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountServer.Repositories
{
    public interface IAccountRepository
    {
        Task<bool> ExistsAccount(string account);
        Task<AccountData> GetByName(string accountName);
        Task RegisterAccount(AccountData account);
        Task UpdatePassword(string accountName, string newPassword);
    }
}
