using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 661, 长度 = 191, 注释 = "查询排行榜单")]
	public sealed class 查询排行榜单 : GamePacket
	{
		
		public 查询排行榜单()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 189)]
		public byte[] 字节数据;
	}
}
