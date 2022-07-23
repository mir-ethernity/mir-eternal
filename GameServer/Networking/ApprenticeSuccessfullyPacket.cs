using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 572, 长度 = 6, 注释 = "ApprenticeSuccessfullyPacket")]
	public sealed class ApprenticeSuccessfullyPacket : GamePacket
	{
		
		public ApprenticeSuccessfullyPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
