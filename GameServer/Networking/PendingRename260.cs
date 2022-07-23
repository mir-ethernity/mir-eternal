using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 552, 长度 = 10, 注释 = "查询行会名字")]
	public sealed class 查询行会名字 : GamePacket
	{
		
		public 查询行会名字()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 行会编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 状态编号;
	}
}
