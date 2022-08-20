using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 164, Length = 8, Description = "GuildWarehouseRefreshPacket")]
	public sealed class GuildWarehouseRefreshPacket : GamePacket
	{
		
		public GuildWarehouseRefreshPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 仓库页面;
	}
}
