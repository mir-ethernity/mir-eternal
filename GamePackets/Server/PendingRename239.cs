using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 286, Length = 0, Description = "查看攻城名单")]
	public sealed class 查看攻城名单 : GamePacket
	{
		
		public 查看攻城名单()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
