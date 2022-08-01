using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 134, 长度 = 2, 注释 = "RepairItemResponsePacket")]
	public sealed class RepairItemResponsePacket : GamePacket
	{
		
		public RepairItemResponsePacket()
		{
			
			
		}
	}
}
