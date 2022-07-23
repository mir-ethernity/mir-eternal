using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 528, 长度 = 6, 注释 = "删除仇人")]
	public sealed class 玩家删除仇人 : GamePacket
	{
		
		public 玩家删除仇人()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
