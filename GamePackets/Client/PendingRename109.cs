using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 114, 长度 = 10, 注释 = "玩家完成任务")]
	public sealed class 玩家完成任务 : GamePacket
	{
		
		public 玩家完成任务()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
