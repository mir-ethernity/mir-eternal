using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 543, 长度 = 6, 注释 = "AppForExpulsionPacket")]
	public sealed class AppForExpulsionPacket : GamePacket
	{
		
		public AppForExpulsionPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
