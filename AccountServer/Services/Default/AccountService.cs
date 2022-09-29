using AccountServer.Exceptions;
using AccountServer.Models;
using AccountServer.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountServer.Services.Default
{
    public class AccountService : IAccountService
    {
        private readonly Random Random = new();
        private readonly string _randomChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWQYZabcdefghijklmnopqrstuvwxyz";
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<AccountService> _logger;

        public AccountService(IAccountRepository accountRepository, ILogger<AccountService> logger)
        {
            _accountRepository = accountRepository;
            _logger = logger;
        }

        public async Task<ChangePasswordResult> ChangePassword(string account, string oldPassword, string newPassword)
        {
            if (!await CheckLogin(account, oldPassword))
                return ChangePasswordResult.AccountNotExistsOrWrongPassword;

            await _accountRepository.UpdatePassword(account, newPassword);

            return ChangePasswordResult.Success;
        }

        public async Task<bool> CheckLogin(string account, string password)
        {
            var data = await _accountRepository.GetByName(account);

            if (data == null)
                return false;

            if (data.Password != password)
                return false;

            return true;
        }

        public async Task<bool> ExistsAccount(string account)
        {
            return await _accountRepository.ExistsAccount(account);
        }

        public string GenerateTicket()
        {
            string text = "ULS21-";
            for (int i = 0; i < 32; i++)
            {
                text += _randomChars[Random.Next(_randomChars.Length)].ToString();
            }
            return text;
        }

        public async Task RegisterAccount(AccountData account)
        {
            await _accountRepository.RegisterAccount(account);
            _logger?.LogInformation($"New account created: {account.Account}");
        }

        public async Task<ResetPasswordResult> ResetPassword(string accountName, string newPassword, string question, string answer)
        {
            if (string.IsNullOrEmpty(newPassword) || newPassword.Length < 6 || newPassword.Length > 18)
                return ResetPasswordResult.NewPasswordNotValid;

            var account = await _accountRepository.GetByName(accountName);

            if (account == null)
                return ResetPasswordResult.AccountInfoNotValid;

            if (!account.Question.Equals(question, StringComparison.InvariantCulture))
                return ResetPasswordResult.AccountInfoNotValid;

            if (!account.Answer.Equals(answer, StringComparison.InvariantCulture))
                return ResetPasswordResult.AccountInfoNotValid;

            await _accountRepository.UpdatePassword(accountName, newPassword);

            return ResetPasswordResult.Success;
        }
    }
}
