using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 599, 长度 = 6, 注释 = "RequestTreasureDataPacket")]
	public sealed class RequestTreasureDataPacket : GamePacket
	{
		
		public RequestTreasureDataPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 数据版本;
	}
}
