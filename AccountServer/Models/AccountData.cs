using System;

namespace AccountServer.Models
{
    public sealed class AccountData
    {
        public string Account { get; set; }
        public bool PasswordEncrypted { get; set; }
        public string Password { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
