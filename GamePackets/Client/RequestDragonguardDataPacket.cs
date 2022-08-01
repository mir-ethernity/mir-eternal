using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 224, 长度 = 6, 注释 = "RequestDragonguardDataPacket")]
	public sealed class RequestDragonguardDataPacket : GamePacket
	{
		
		public RequestDragonguardDataPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
