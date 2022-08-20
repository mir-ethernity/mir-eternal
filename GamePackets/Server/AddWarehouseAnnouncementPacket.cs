using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 618, Length = 107, Description = "AddWarehouseAnnouncementPacket")]
	public sealed class AddWarehouseAnnouncementPacket : GamePacket
	{
		
		public AddWarehouseAnnouncementPacket()
		{
			
			
		}
	}
}
