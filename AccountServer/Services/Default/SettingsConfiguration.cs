using AccountServer.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
