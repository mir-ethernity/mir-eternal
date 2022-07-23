using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 224, 长度 = 6, 注释 = "RequestDragonguardDataPacket")]
	public sealed class RequestDragonguardDataPacket : GamePacket
	{
		
		public RequestDragonguardDataPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
