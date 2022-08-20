using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 114, Length = 10, Description = "玩家完成任务")]
	public sealed class 玩家完成任务 : GamePacket
	{
		
		public 玩家完成任务()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
