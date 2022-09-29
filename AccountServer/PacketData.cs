using System.Net;

namespace AccountServer
{
    public struct PacketData
    {
        public IPEndPoint ClientAddress;
        public byte[] ReceivedData;
    }
}
