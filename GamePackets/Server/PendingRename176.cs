using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 574, Length = 0, Description = "QueryMailboxContentPacket")]
	public sealed class 同步邮箱内容 : GamePacket
	{
		
		public 同步邮箱内容()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节数据;
	}
}
