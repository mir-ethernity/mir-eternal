using GameServer;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackets.Client
{
    [PacketInfo(Source = PacketSource.Client, Id = 226, Length = 4, Description = "UpgradeAwakeningSkillPacket")]
    public class UpgradeAwakeningSkillPacket : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 2)]
        public ushort SkillId;
    }
}
