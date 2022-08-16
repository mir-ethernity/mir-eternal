using AccountServer;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAccountServer.Repository
{
    public class AccountModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }

    public class AccountRepository
    {
        private readonly NpgsqlConnection _db;

        public AccountRepository(NpgsqlConnection db)
        {
            _db = db;
        }

        public void Register(AccountData account)
        {
            _db.Execute("insert into public.accounts (username, password, question, answer) values (@username, @password, @question, @answer)", new
            {
                username = account.Account,
                password = BCrypt.Net.BCrypt.HashPassword(account.Password),
                question = account.Question,
                answer = account.Answer
            });
        }

        public bool Login(string username, string password)
        {
            var account = _db.QueryFirstOrDefault<AccountModel>("select * from public.accounts where username = @username", new
            {
                username
            });

            return account != null && BCrypt.Net.BCrypt.Verify(password, account.Password);
        }

        public bool Exists(string username)
        {
            var account = _db.QueryFirstOrDefault<AccountModel>("select * from public.accounts where username = @username", new
            {
                username
            });

            return account != null;
        }

        public AccountModel GetByUsername(string username)
        {
            var account = _db.QueryFirstOrDefault<AccountModel>("select * from public.accounts where username = @username", new
            {
                username
            });

            return account;
        }

        internal void ChangePassword(string username, string password)
        {
            _db.Execute("update public.accounts set password = @password where username = @username", new
            {
                username,
                password = BCrypt.Net.BCrypt.HashPassword(password)
            });
        }
    }
}
