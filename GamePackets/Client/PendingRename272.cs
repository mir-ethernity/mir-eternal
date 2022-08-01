using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 110, 长度 = 3, 注释 = "更改摊位外观")]
	public sealed class 更改摊位外观 : GamePacket
	{
		
		public 更改摊位外观()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 外观编号;
	}
}
