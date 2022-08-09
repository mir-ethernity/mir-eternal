using AccountServer;
using Npgsql;
using SimpleMigrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using XAccountServer.Repository;

namespace XAccountServer
{
    public static class SEnvir
    {
        //public static Dictionary<string, AccountData> AccountData { get; } = new Dictionary<string, AccountData>();

        public static uint TotalTickets { get; set; }
        public static uint TotalNewAccounts { get; internal set; }
        public static long TotalBytesSended { get; internal set; }
        public static NpgsqlConnection DBConnection { get; private set; }
        public static AccountRepository Accounts { get; private set; }

        public static bool Start()
        {
            if (!LoadDatabase())
                return false;

            // LoadAccounts();
            foreach (var server in Config.Servers)
            {
                var result = Dns.GetHostEntry(server.PublicIP);
                server.PublicIP = result.AddressList[0].ToString();
                result = Dns.GetHostEntry(server.PrivateIP);
                server.PrivateIP = result.AddressList[0].ToString();
                Console.WriteLine($"GS: {server.PrivateIP},{server.PublicIP},{server.Port}/{server.Name}");
            }
            Network.Start();

            return true;
        }

        private static bool LoadDatabase()
        {
            try
            {
                DBConnection = new NpgsqlConnection($"User ID={Config.Database.User};Password={Config.Database.Pass};Host={Config.Database.Host};Port={Config.Database.Port};Database={Config.Database.DBName};");
                DBConnection.Open();

                var dbProvider = new SimpleMigrations.DatabaseProvider.PostgresqlDatabaseProvider(DBConnection);
                var migrator = new SimpleMigrator(typeof(SEnvir).Assembly, dbProvider);
                migrator.Load();
                migrator.MigrateToLatest();

                Accounts = new AccountRepository(DBConnection);

                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error ocurred connecting to database: {ex}");
                return false;
            }
        }

        //private static void LoadAccounts()
        //{
        //    AccountData.Clear();

        //    if (!Directory.Exists(Config.DataDirectory))
        //    {
        //        Console.WriteLine("Account Directory does not exist. It has been created automatically.");
        //        Directory.CreateDirectory(Config.DataDirectory);
        //        return;
        //    }
        //    object[] array = Serializer.Deserialize(Config.DataDirectory, typeof(AccountData));
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        AccountData? accountData = array[i] as AccountData;
        //        if (accountData != null)
        //        {
        //            AccountData[accountData.Account] = accountData;
        //        }
        //    }
        //    Console.WriteLine(string.Format("Accounts Loaded: {0}", AccountData.Count));
        //}

        public static bool TryGetServerConfig(string name, out ServerConfig? serverConfig)
        {
            serverConfig = Config.Servers.Where(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            return serverConfig != null;
        }
    }
}
