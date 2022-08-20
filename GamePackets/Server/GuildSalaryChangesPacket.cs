using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 619, Length = 6, Description = "GuildSalaryChangesPacket")]
	public sealed class GuildSalaryChangesPacket : GamePacket
	{
		
		public GuildSalaryChangesPacket()
		{
			
			
		}
	}
}
