using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 82, Length = 7, Description = "玩家名字变灰", Broadcast = true)]
	public sealed class 玩家名字变灰 : GamePacket
	{
		
		public 玩家名字变灰()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public bool 是否灰名;
	}
}
