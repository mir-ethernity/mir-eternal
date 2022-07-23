using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 571, 长度 = 6, 注释 = "CongratsToApprenticeForAnsweringPacket")]
	public sealed class CongratsToApprenticeForAnsweringPacket : GamePacket
	{
		
		public CongratsToApprenticeForAnsweringPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 徒弟编号;
	}
}
