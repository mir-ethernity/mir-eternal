using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 661, Length = 191, Description = "查询排行榜单")]
	public sealed class 查询排行榜单 : GamePacket
	{
		
		public 查询排行榜单()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 189)]
		public byte[] 字节数据;
	}
}
