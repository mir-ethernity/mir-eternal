using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 573, 长度 = 8, 注释 = "GuildWarehouseMovePacket")]
	public sealed class GuildWarehouseMovePacket : GamePacket
	{
		
		public GuildWarehouseMovePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 原有页面;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 原有位置;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 目标页面;

		
		[WrappingFieldAttribute(下标 = 5, 长度 = 1)]
		public byte 目标位置;
	}
}
