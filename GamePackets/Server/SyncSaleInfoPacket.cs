using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 660, Length = 0, Description = "查询出售信息")]
	public sealed class SyncSaleInfoPacket : GamePacket
	{
		
		public SyncSaleInfoPacket()
		{
			
			
		}
	}
}
