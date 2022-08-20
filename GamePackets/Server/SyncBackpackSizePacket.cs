using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 15, Length = 11, Description = "SyncBackpackSizePacket 仓库 背包 资源包...")]
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

		[WrappingFieldAttribute(SubScript = 5, Length = 1)]
		public byte u1;

		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte u2;

		[WrappingFieldAttribute(SubScript = 7, Length = 1)]
		public byte u3;

		[WrappingFieldAttribute(SubScript = 8, Length = 1)]
		public byte u4;

		[WrappingFieldAttribute(SubScript = 9, Length = 1)]
		public byte ExtraBackpackSize;

		[WrappingFieldAttribute(SubScript = 10, Length = 1)]
		public byte u5;
	}
}
