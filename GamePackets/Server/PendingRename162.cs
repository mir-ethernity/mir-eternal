using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 110, Length = 7, Description = "同步PK模式")]
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
