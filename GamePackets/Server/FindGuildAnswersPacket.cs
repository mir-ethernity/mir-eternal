using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 586, Length = 231, Description = "FindGuildAnswersPacket")]
	public sealed class FindGuildAnswersPacket : GamePacket
	{
		
		public FindGuildAnswersPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 229)]
		public byte[] 字节数据;
	}
}
