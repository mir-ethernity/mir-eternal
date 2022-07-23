using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 548, 长度 = 2, 注释 = "QueryMailboxContentPacket")]
	public sealed class QueryMailboxContentPacket : GamePacket
	{
		
		public QueryMailboxContentPacket()
		{
			
			
		}
	}
}
