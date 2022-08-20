using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 604, Length = 10, Description = "查询排名榜单")]
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
