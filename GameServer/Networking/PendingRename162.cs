using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 110, 长度 = 7, 注释 = "同步PK模式")]
	public sealed class 同步对战模式 : GamePacket
	{
		
		public 同步对战模式()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte AttackMode;
	}
}
