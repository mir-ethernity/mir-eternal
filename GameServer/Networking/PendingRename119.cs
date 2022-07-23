using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 537, 长度 = 6, 注释 = "添加仇人")]
	public sealed class 玩家标记仇人 : GamePacket
	{
		
		public 玩家标记仇人()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
