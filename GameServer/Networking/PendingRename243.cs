using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 604, 长度 = 10, 注释 = "查询排名榜单")]
	public sealed class 查询排名榜单 : GamePacket
	{
		
		public 查询排名榜单()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 榜单类型;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 起始位置;
	}
}
