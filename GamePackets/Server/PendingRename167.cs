using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 78, 长度 = 14, 注释 = "同步hp")]
	public sealed class 同步对象体力 : GamePacket
	{
		
		public 同步对象体力()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 当前体力;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 4)]
		public int 体力上限;
	}
}
