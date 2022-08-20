using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 83, Length = 7, Description = "玩家装配称号", Broadcast = true)]
	public sealed class 同步装配称号 : GamePacket
	{
		
		public 同步装配称号()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte Id;
	}
}
