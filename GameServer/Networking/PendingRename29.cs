using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 54, 长度 = 2, 注释 = "商店修理全部")]
	public sealed class 商店修理全部 : GamePacket
	{
		
		public 商店修理全部()
		{
			
			
		}
	}
}
