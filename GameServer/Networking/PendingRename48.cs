using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 108, 长度 = 3, 注释 = "取回摊位物品")]
	public sealed class 取回摊位物品 : GamePacket
	{
		
		public 取回摊位物品()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 取回位置;
	}
}
