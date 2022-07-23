using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 156, 长度 = 6, 注释 = "玩家比较成就")]
	public sealed class 玩家比较成就 : GamePacket
	{
		
		public 玩家比较成就()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
