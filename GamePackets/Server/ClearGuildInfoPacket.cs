using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 569, 长度 = 2, 注释 = "ClearGuildInfoPacket")]
	public sealed class ClearGuildInfoPacket : GamePacket
	{
		
		public ClearGuildInfoPacket()
		{
			
			
		}
	}
}
