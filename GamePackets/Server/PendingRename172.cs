using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 288, Length = 5, Description = "同步签到信息")]
	public sealed class 同步签到信息 : GamePacket
	{
		
		public 同步签到信息()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public bool 能否签到;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 签到次数;
	}
}
