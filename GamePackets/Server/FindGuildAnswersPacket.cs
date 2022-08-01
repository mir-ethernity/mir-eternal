using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 586, 长度 = 231, 注释 = "FindGuildAnswersPacket")]
	public sealed class FindGuildAnswersPacket : GamePacket
	{
		
		public FindGuildAnswersPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 229)]
		public byte[] 字节数据;
	}
}
