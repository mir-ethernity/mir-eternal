using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 569, Length = 2, Description = "ClearGuildInfoPacket")]
	public sealed class ClearGuildInfoPacket : GamePacket
	{
		
		public ClearGuildInfoPacket()
		{
			
			
		}
	}
}
