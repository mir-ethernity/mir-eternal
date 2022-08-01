using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 79, 长度 = 6, 注释 = "同步mp")]
	public sealed class 同步对象魔力 : GamePacket
	{
		
		public 同步对象魔力()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 当前魔力;
	}
}
