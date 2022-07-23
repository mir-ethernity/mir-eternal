using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 586, 长度 = 231, 注释 = "FindGuildAnswersPacket")]
	public sealed class FindGuildAnswersPacket : GamePacket
	{
		
		public FindGuildAnswersPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 229)]
		public byte[] 字节数据;
	}
}
