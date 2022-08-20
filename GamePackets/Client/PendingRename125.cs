using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 115, Length = 6, Description = "玩家放弃任务")]
	public sealed class 玩家放弃任务 : GamePacket
	{
		
		public 玩家放弃任务()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
