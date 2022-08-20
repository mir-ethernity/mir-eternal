using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 254, Length = 6, Description = "购买每周特惠")]
	public sealed class 购买每周特惠 : GamePacket
	{
		
		public 购买每周特惠()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 礼包编号;
	}
}
