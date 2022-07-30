using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 553, 长度 = 6, 注释 = "RefusalApprenticePacket")]
	public sealed class RefusalApprenticePacket : GamePacket
	{
		
		public RefusalApprenticePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
