using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 165, 长度 = 8, 注释 = "GuildWarehouseTransferPacket")]
	public sealed class GuildWarehouseTransferPacket : GamePacket
	{
		
		public GuildWarehouseTransferPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 原来容器;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 原来位置;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 仓库页面;

		
		[WrappingFieldAttribute(下标 = 7, 长度 = 1)]
		public byte 仓库位置;
	}
}
