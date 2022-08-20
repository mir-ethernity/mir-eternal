using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 24, Length = 3, Description = "玩家请求复活")]
	public sealed class 客户请求复活 : GamePacket
	{
		
		public 客户请求复活()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 复活方式;
	}
}
