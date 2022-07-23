using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 24, 长度 = 3, 注释 = "玩家请求复活")]
	public sealed class 客户请求复活 : GamePacket
	{
		
		public 客户请求复活()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 复活方式;
	}
}
