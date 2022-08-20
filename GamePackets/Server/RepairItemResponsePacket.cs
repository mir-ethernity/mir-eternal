using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 134, Length = 2, Description = "RepairItemResponsePacket")]
	public sealed class RepairItemResponsePacket : GamePacket
	{
		
		public RepairItemResponsePacket()
		{
			
			
		}
	}
}
