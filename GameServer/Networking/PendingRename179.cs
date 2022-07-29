using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 620, 长度 = 0, 注释 = "更多GuildEvents")]
	public sealed class 同步GuildEvents : GamePacket
	{
		
		public 同步GuildEvents()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节数据;
	}
}
