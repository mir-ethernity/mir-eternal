using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 579, Length = 27, Description = "StartGuildWarPacket")]
	public sealed class StartGuildWarPacket : GamePacket
	{
		
		public StartGuildWarPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 25)]
		public string GuildName;
	}
}
