using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountServer.Models;

namespace AccountServer.Repositories
{
    public interface IAccountRepository
    {
        Task<bool> ExistsAccount(string account);
        Task<AccountData> GetByName(string accountName);
        Task<AccountData> RegisterAccount(string account, string password, string question, string answer);
        Task UpdatePassword(string accountName, string newPassword);
        Task<int> GetTotalAccounts();
    }
}
