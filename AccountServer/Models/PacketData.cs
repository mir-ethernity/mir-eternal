using System.Net;

namespace AccountServer.Models
{
    public struct PacketData
    {
        public IPEndPoint ClientAddress;
        public byte[] ReceivedData;
    }
}
