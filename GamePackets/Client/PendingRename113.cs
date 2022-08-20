using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 181, Length = 6, Description = "玩家解除屏蔽")]
	public sealed class 玩家解除屏蔽 : GamePacket
	{
		
		public 玩家解除屏蔽()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
