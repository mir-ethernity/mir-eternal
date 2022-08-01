using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 181, 长度 = 6, 注释 = "玩家解除屏蔽")]
	public sealed class 玩家解除屏蔽 : GamePacket
	{
		
		public 玩家解除屏蔽()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
