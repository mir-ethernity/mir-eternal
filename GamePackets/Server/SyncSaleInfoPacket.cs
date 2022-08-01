using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 660, 长度 = 0, 注释 = "查询出售信息")]
	public sealed class SyncSaleInfoPacket : GamePacket
	{
		
		public SyncSaleInfoPacket()
		{
			
			
		}
	}
}
