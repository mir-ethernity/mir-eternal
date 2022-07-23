using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 581, 长度 = 6, 注释 = "开启行会活动")]
	public sealed class 开启行会活动 : GamePacket
	{
		
		public 开启行会活动()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 活动编号;
	}
}
