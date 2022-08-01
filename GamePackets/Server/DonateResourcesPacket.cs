using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 603, 长度 = 10, 注释 = "DonateResourcesPacket")]
	public sealed class DonateResourcesPacket : GamePacket
	{
		
		public DonateResourcesPacket()
		{
			
			
		}
	}
}
