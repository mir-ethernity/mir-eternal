using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 599, 长度 = 6, 注释 = "RequestTreasureDataPacket")]
	public sealed class RequestTreasureDataPacket : GamePacket
	{
		
		public RequestTreasureDataPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 数据版本;
	}
}
