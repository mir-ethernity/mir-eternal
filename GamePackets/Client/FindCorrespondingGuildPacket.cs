using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 555, Length = 31, Description = "FindCorrespondingGuildPacket")]
	public sealed class FindCorrespondingGuildPacket : GamePacket
	{
		
		public FindCorrespondingGuildPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 行会编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 25)]
		public string GuildName;
	}
}
