using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 581, Length = 6, Description = "开启行会活动")]
	public sealed class 开启行会活动 : GamePacket
	{
		
		public 开启行会活动()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 活动编号;
	}
}
