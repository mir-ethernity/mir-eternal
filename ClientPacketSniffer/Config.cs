using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientPacketSniffer
{
    public static class Config
    {
        public static int TcpLocalPort { get; set; } = 8001;
        public static string TcpRemoteIP { get; set; } = string.Empty;
        public static int TcpRemotePort { get; set; } = 8001;

        public static int UdpLocalPort { get; set; } = 8001;
        public static string UdpRemoteIP { get; set; } = string.Empty;
        public static int UdpRemotePort { get; set; } = 8001;

        public static int BufferSize { get; set; } = 8192;
    }
}
