using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 65, 长度 = 6, 注释 = "RequestStoreDataPacket")]
	public sealed class RequestStoreDataPacket : GamePacket
	{
		
		public RequestStoreDataPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 版本编号;
	}
}
