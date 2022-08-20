using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 534, Length = 6, Description = "玩家申请拜师")]
	public sealed class 玩家申请拜师 : GamePacket
	{
		
		public 玩家申请拜师()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
