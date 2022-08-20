using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 109, Length = 35, Description = "更改摊位名字")]
	public sealed class 更改摊位名字 : GamePacket
	{
		
		public 更改摊位名字()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 33)]
		public string 摊位名字;
	}
}
