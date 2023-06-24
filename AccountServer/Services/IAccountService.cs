using AccountServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountServer.Services
{
    public interface IAccountService
    {
        string GenerateTicket();
        Task<AccountData> RegisterAccount(string account, string password, string question, string answer);
        Task<ChangePasswordResult> ChangePassword(string account, string oldPassword, string newPassword);
        Task<ResetPasswordResult> ResetPassword(string account, string newPassword, string question, string answer);
        Task<bool> CheckLogin(string account, string password);
        Task<bool> ExistsAccount(string account);
    }
}
