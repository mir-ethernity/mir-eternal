using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 588, Length = 38, Description = "玩家屏蔽对象")]
	public sealed class 玩家屏蔽对象 : GamePacket
	{
		
		public 玩家屏蔽对象()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
