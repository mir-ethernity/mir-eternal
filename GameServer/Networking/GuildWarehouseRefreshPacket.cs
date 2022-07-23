using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 164, 长度 = 8, 注释 = "GuildWarehouseRefreshPacket")]
	public sealed class GuildWarehouseRefreshPacket : GamePacket
	{
		
		public GuildWarehouseRefreshPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 仓库页面;
	}
}
