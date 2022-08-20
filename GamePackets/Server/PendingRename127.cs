using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 250, Length = 38, Description = "玩家屏蔽目标")]
	public sealed class 玩家屏蔽目标 : GamePacket
	{
		
		public 玩家屏蔽目标()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 32)]
		public string 对象名字;
	}
}
