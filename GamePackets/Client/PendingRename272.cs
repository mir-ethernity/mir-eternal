using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 110, Length = 3, Description = "更改摊位外观")]
	public sealed class 更改摊位外观 : GamePacket
	{
		
		public 更改摊位外观()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 外观编号;
	}
}
