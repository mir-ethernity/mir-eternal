using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 603, 长度 = 10, 注释 = "DonateResourcesPacket")]
	public sealed class DonateResourcesPacket : GamePacket
	{
		
		public DonateResourcesPacket()
		{
			
			
		}
	}
}
