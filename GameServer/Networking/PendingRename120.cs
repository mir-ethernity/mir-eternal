using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 527, 长度 = 6, 注释 = "添加仇人")]
	public sealed class 玩家添加仇人 : GamePacket
	{
		
		public 玩家添加仇人()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
