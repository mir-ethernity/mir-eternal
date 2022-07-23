using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1, 长度 = 8, 注释 = "GatewayQueryResponsePacket")]
	public sealed class GatewayQueryResponsePacket : GamePacket
	{
		
		public GatewayQueryResponsePacket()
		{
			
			
		}
	}
}
