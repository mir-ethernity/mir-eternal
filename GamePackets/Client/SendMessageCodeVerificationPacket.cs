using GameServer;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackets.Client
{
    [PacketInfo(Source = PacketSource.Client, Id = 610, Length = 9, Description = "SendMessageCodeVerificationPacket")]
    public class SendMessageCodeVerificationPacket : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 7)]
        public string Code;
    }
}
