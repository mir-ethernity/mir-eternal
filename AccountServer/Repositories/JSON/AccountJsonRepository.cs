using AccountServer.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountServer.Repositories.JSON
{
    public class AccountJsonRepository : IAccountRepository
    {
        public readonly string DataDirectory = Path.GetFullPath("Accounts", Environment.CurrentDirectory);
        public readonly Dictionary<string, AccountData> Accounts = new Dictionary<string, AccountData>();

        public AccountJsonRepository()
        {
            Initialize();
        }

        public Task<bool> ExistsAccount(string account)
        {
            return Task.FromResult(Accounts.ContainsKey(account.ToLowerInvariant()));
        }

        public Task<AccountData> GetByName(string accountName)
        {
            if (Accounts.TryGetValue(accountName, out var account))
                return Task.FromResult(account);

            return Task.FromResult<AccountData>(null);
        }

        public async Task RegisterAccount(AccountData account)
        {
            if (Accounts.ContainsKey(account.Account.ToLowerInvariant()))
                throw new AccountAlreadyRegisteredException(account.Account);

            await SaveAccount(account);
        }

        public async Task UpdatePassword(string accountName, string newPassword)
        {
            if (!Accounts.TryGetValue(accountName, out var account))
                throw new AccountNotExistsException(accountName);

            account.Password = newPassword;

            await SaveAccount(account);
        }

        private void Initialize()
        {
            if (!Directory.Exists(DataDirectory))
                Directory.CreateDirectory(DataDirectory);

            Accounts.Clear();

            var jsons = Directory.GetFiles(DataDirectory, "*.txt", SearchOption.TopDirectoryOnly);

            foreach (var json in jsons)
            {
                var content = File.ReadAllText(json, Encoding.UTF8);
                var account = JsonConvert.DeserializeObject<AccountData>(content);
                Accounts.Add(account.Account.ToLowerInvariant(), account);
            }
        }

        private async Task SaveAccount(AccountData account)
        {
            var json = JsonConvert.SerializeObject(account);
            var path = Path.Combine(DataDirectory, $"{account.Account}.txt");

            await File.WriteAllTextAsync(path, json);
        }
    }
}
