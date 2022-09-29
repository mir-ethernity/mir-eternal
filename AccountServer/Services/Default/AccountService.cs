using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountServer.Services.Default
{
    public class AccountService : IAccountService
    {
        private readonly Random Random = new();

        public string RandomChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWQYZabcdefghijklmnopqrstuvwxyz";

        public string GenerateTickets()
        {
            string text = "ULS21-";
            for (int i = 0; i < 32; i++)
            {
                text += RandomChars[Random.Next(RandomChars.Length)].ToString();
            }
            return text;
        }
    }
}
