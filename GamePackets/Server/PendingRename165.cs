using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 71, Length = 36, Description = "同步对象Buff")]
	public sealed class 同步对象Buff : GamePacket
	{
		
		public 同步对象Buff()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 34)]
		public byte[] 字节描述;
	}
}
