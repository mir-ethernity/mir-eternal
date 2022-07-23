using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 110, 长度 = 7, 注释 = "同步PK模式")]
	public sealed class 同步对战模式 : GamePacket
	{
		
		public 同步对战模式()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte AttackMode;
	}
}
