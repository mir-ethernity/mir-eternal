using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 523, Length = 7, Description = "同步队员状态")]
	public sealed class 同步队员状态 : GamePacket
	{
		
		public 同步队员状态()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 状态编号;
	}
}
