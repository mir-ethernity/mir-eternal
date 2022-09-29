using AccountServer.Models;
using AccountServer.Properties;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountServer.Services.Default
{
    public class SettingsConfiguration : IAppConfiguration
    {
        public ushort LoginGatePort
        {
            get => Settings.Default.TSPort;
            set
            {
                Settings.Default.TSPort = value;
                Settings.Default.Save();
            }
        }
        public ushort AccountServerPort
        {
            get => Settings.Default.ASPort;
            set
            {
                Settings.Default.ASPort = value;
                Settings.Default.Save();
            }
        }

        public IDictionary<string, GameServerInfo> Servers { get; private set; }

        public string PublicServerInfo => string.Join("\n", Servers.Values.Select(x => $"{x.PublicAddress.Address},{x.PublicAddress.Port}/{x.Name}"));

        public SettingsConfiguration(ILogger<SettingsConfiguration> logger)
        {
            Servers = new Dictionary<string, GameServerInfo>();
            var serversInfo = File.ReadAllText(".\\server", Encoding.UTF8).Trim('\r', '\n', ' ');
            foreach (string serverInfo in serversInfo.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] array2 = serverInfo.Split(new char[] { ',', '/' }, StringSplitOptions.RemoveEmptyEntries);
                if (array2.Length != 3)
                {
                    logger.LogCritical($"Server configuration error, parsing error. Line: {serverInfo}");
                    continue;
                }

                Servers.Add(array2[2], new GameServerInfo
                {
                    InternalAddress = new IPEndPoint(IPAddress.Parse(array2[0]), Convert.ToInt32(array2[1])),
                    PublicAddress = new IPEndPoint(IPAddress.Parse(array2[0]), Convert.ToInt32(array2[1])),
                    Name = array2[2]
                });
            }
        }
    }
}
