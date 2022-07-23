using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 569, 长度 = 2, 注释 = "ClearGuildInfoPacket")]
	public sealed class ClearGuildInfoPacket : GamePacket
	{
		
		public ClearGuildInfoPacket()
		{
			
			
		}
	}
}
