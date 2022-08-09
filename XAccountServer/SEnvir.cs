using AccountServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace XAccountServer
{
    public static class SEnvir
    {
        public static Dictionary<string, AccountData> AccountData { get; } = new Dictionary<string, AccountData>();
        public static uint TotalTickets { get; set; }
        public static uint TotalNewAccounts { get; internal set; }
        public static long TotalBytesSended { get; internal set; }

        public static void Start()
        {
            LoadAccounts();
            foreach (var server in Config.Servers)
            {
                var result = Dns.GetHostEntry(server.PublicIP);
                server.PublicIP = result.AddressList[0].Address.ToString();
                result = Dns.GetHostEntry(server.PrivateIP);
                server.PrivateIP = result.AddressList[0].Address.ToString();
                Console.WriteLine($"GS: {server.PrivateIP},{server.PublicIP},{server.Port}/{server.Name}");
            }
            Network.Start();
        }

        private static void LoadAccounts()
        {
            AccountData.Clear();

            if (!Directory.Exists(Config.DataDirectory))
            {
                Console.WriteLine("Account Directory does not exist. It has been created automatically.");
                Directory.CreateDirectory(Config.DataDirectory);
                return;
            }
            object[] array = Serializer.Deserialize(Config.DataDirectory, typeof(AccountData));
            for (int i = 0; i < array.Length; i++)
            {
                AccountData? accountData = array[i] as AccountData;
                if (accountData != null)
                {
                    AccountData[accountData.Account] = accountData;
                }
            }
            Console.WriteLine(string.Format("Accounts Loaded: {0}", AccountData.Count));
        }

        public static bool TryGetServerConfig(string name, out ServerConfig? serverConfig)
        {
            serverConfig = Config.Servers.Where(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            return serverConfig != null;
        }

        public static void SaveAccount(AccountData account)
        {
            File.WriteAllText(Path.Combine(Config.DataDirectory, account.Account + ".txt"), Serializer.Serialize(account));
        }

        public static void AddAccount(AccountData account)
        {
            if (!AccountData.ContainsKey(account.Account))
            {
                AccountData[account.Account] = account;
                SaveAccount(account);
            }
        }
    }
}
