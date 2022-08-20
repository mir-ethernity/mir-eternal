using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 593, Length = 6, Description = "GuildRemoveMemberPacket")]
	public sealed class GuildRemoveMemberPacket : GamePacket
	{
		
		public GuildRemoveMemberPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
