using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 165, 长度 = 8, 注释 = "GuildWarehouseTransferPacket")]
	public sealed class GuildWarehouseTransferPacket : GamePacket
	{
		
		public GuildWarehouseTransferPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 原来容器;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 原来位置;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 仓库页面;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 1)]
		public byte 仓库位置;
	}
}
