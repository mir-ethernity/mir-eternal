using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 1, 长度 = 15, 注释 = "GatewayQueryResponsePacket")]
	public sealed class GatewayQueryResponsePacket : GamePacket
	{
		
		public GatewayQueryResponsePacket()
		{
			
			
		}
	}
}
