using GameServer;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackets.Client
{
    [PacketInfo(Source = PacketSource.Client, Id = 219, Length = 5, Description = "AddMountSkillPacket")]
    public class AddMountSkillPacket : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 2)]
        public ushort Field;

        [WrappingField(SubScript = 4, Length = 1)]
        public byte Unknown;
    }
}
