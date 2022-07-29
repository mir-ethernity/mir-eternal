using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 134, 长度 = 3, 注释 = "ToggleMapRoutePacket")]
	public sealed class ToggleMapRoutePacket : GamePacket
	{
		
		public ToggleMapRoutePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 地图路线;
	}
}
