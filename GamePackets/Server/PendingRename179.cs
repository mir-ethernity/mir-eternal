using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 620, Length = 0, Description = "更多GuildEvents")]
	public sealed class 同步GuildEvents : GamePacket
	{
		
		public 同步GuildEvents()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节数据;
	}
}
