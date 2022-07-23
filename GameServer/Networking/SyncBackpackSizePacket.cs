using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 15, 长度 = 11, 注释 = "SyncBackpackSizePacket 仓库 背包 资源包...")]
	public sealed class SyncBackpackSizePacket : GamePacket
	{
		
		public SyncBackpackSizePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 穿戴大小;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 背包大小;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 仓库大小;
	}
}
