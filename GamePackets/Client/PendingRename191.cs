using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 216, Length = 4, Description = "领取特权礼包")]
	public sealed class 领取特权礼包 : GamePacket
	{
		
		public 领取特权礼包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 特权类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 礼包位置;
	}
}
