using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 15, 长度 = 11, 注释 = "SyncBackpackSizePacket 仓库 背包 资源包...")]
	public sealed class SyncBackpackSizePacket : GamePacket
	{
		
		public SyncBackpackSizePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 穿戴大小;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte BackpackSize;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte WarehouseSize;

		[WrappingFieldAttribute(SubScript = 9, Length = 1)]
		public byte ExtraBackpackSize;
	}
}
