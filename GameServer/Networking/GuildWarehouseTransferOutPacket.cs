using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 166, 长度 = 8, 注释 = "GuildWarehouseTransferOutPacket")]
	public sealed class GuildWarehouseTransferOutPacket : GamePacket
	{
		
		public GuildWarehouseTransferOutPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 仓库页面;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 仓库位置;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 目标容器;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 目标位置;
	}
}
