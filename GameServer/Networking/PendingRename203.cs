using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 254, 长度 = 6, 注释 = "购买每周特惠")]
	public sealed class 购买每周特惠 : GamePacket
	{
		
		public 购买每周特惠()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 礼包编号;
	}
}
