using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 589, Length = 0, Description = "查看申请名单")]
	public sealed class 查看申请名单 : GamePacket
	{
		
		public 查看申请名单()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
