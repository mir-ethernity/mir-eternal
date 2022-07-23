using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 78, 长度 = 14, 注释 = "同步hp")]
	public sealed class 同步对象体力 : GamePacket
	{
		
		public 同步对象体力()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 当前体力;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public int 体力上限;
	}
}
