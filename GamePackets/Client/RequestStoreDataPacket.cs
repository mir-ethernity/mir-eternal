using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 65, 长度 = 6, 注释 = "RequestStoreDataPacket")]
	public sealed class RequestStoreDataPacket : GamePacket
	{
		
		public RequestStoreDataPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 版本编号;
	}
}
