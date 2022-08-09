using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace XAccountServer
{
    public class ServerConfig
    {
        public string Name { get; set; }
        public string PrivateIP { get; set; }
        public string PublicIP { get; set; }
        public ushort Port { get; set; }
    }

    public class DatabaseConfig
    {
        public string Host { get; set; }
        public ushort Port { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string DBName { get; set; }
    }
    public static class Config
    {
        public static ushort LoginGatePort { get; set; }
        public static ushort LoginServerPort { get; set; }
        public static IEnumerable<ServerConfig> Servers { get; set; } = new List<ServerConfig>();
        public static DatabaseConfig Database { get; set; }
        public static string DataDirectory { get; set; } = "./Accounts";
        public static string GameServerArea => string.Join("\r\n", Servers.Select(x => $"{x.PublicIP},{x.Port}/{x.Name}"));
    }
}
