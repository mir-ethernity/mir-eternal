using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 533, Length = 6, Description = "取消关注")]
	public sealed class 玩家取消关注 : GamePacket
	{
		
		public 玩家取消关注()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
