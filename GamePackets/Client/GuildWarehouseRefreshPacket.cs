using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 164, 长度 = 8, 注释 = "GuildWarehouseRefreshPacket")]
	public sealed class GuildWarehouseRefreshPacket : GamePacket
	{
		
		public GuildWarehouseRefreshPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 仓库页面;
	}
}
