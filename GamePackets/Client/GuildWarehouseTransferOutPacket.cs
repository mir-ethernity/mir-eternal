using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 166, 长度 = 8, 注释 = "GuildWarehouseTransferOutPacket")]
	public sealed class GuildWarehouseTransferOutPacket : GamePacket
	{
		
		public GuildWarehouseTransferOutPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 仓库页面;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 仓库位置;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 目标容器;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 目标位置;
	}
}
