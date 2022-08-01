using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 115, 长度 = 6, 注释 = "玩家放弃任务")]
	public sealed class 玩家放弃任务 : GamePacket
	{
		
		public 玩家放弃任务()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
