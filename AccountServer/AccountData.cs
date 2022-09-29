using System;

namespace AccountServer
{
    public sealed class AccountData
    {
        public AccountData(string account, string password, string securityQuestion, string securityAnswer)
        {
            this.Account = account;
            this.Password = password;
            this.Question = securityQuestion;
            this.Answer = securityAnswer;
            this.CreatedDate = DateTime.Now;
        }

        public string Account;
        public string Password;
        public string Question;
        public string Answer;

        public DateTime CreatedDate;
    }
}
