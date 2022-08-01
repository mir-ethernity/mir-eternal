using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 618, 长度 = 107, 注释 = "AddWarehouseAnnouncementPacket")]
	public sealed class AddWarehouseAnnouncementPacket : GamePacket
	{
		
		public AddWarehouseAnnouncementPacket()
		{
			
			
		}
	}
}
