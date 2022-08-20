using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 613, Length = 4, Description = "购买玛法特权")]
	public sealed class 购买玛法特权 : GamePacket
	{
		
		public 购买玛法特权()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 特权类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 购买数量;
	}
}
