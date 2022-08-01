using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 581, 长度 = 6, 注释 = "开启行会活动")]
	public sealed class 开启行会活动 : GamePacket
	{
		
		public 开启行会活动()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 活动编号;
	}
}
