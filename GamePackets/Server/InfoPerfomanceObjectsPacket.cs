using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 681, 长度 = 38, 注释 = "InfoPerfomanceObjectsPacket")]
	public sealed class InfoPerfomanceObjectsPacket : GamePacket
	{
		
		public InfoPerfomanceObjectsPacket()
		{
			
			
		}
	}
}
