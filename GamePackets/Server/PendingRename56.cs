using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 564, Length = 6, Description = "离开师门提示")]
	public sealed class 离开师门提示 : GamePacket
	{
		
		public 离开师门提示()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
