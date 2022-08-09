using System.Net;

namespace AccountServer
{
    public sealed partial class Network
    {
        public struct PacketData
        {
            public IPEndPoint ClientAddress;
            public byte[] ReceivedData;
        }
    }
}
