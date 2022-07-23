using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 588, 长度 = 38, 注释 = "玩家屏蔽对象")]
	public sealed class 玩家屏蔽对象 : GamePacket
	{
		
		public 玩家屏蔽对象()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
