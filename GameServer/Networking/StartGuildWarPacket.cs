using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 579, 长度 = 27, 注释 = "StartGuildWarPacket")]
	public sealed class StartGuildWarPacket : GamePacket
	{
		
		public StartGuildWarPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 25)]
		public string GuildName;
	}
}
