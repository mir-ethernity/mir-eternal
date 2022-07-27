using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 250, 长度 = 38, 注释 = "玩家屏蔽目标")]
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
