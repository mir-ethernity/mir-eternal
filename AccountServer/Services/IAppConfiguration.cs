using AccountServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountServer.Services
{
    public interface IAppConfiguration
    {
        ushort LoginGatePort { get; set; }
        ushort AccountServerPort { get; set; }
        IDictionary<string, GameServerInfo> Servers { get; }
        string PublicServerInfo => string.Join("\n", Servers.Values.Select(x => $"{x.PublicAddress.Address},{x.PublicAddress.Port}/{x.Name}"));
    }
}
