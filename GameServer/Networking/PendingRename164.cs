using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 79, 长度 = 6, 注释 = "同步mp")]
	public sealed class 同步对象魔力 : GamePacket
	{
		
		public 同步对象魔力()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 当前魔力;
	}
}
