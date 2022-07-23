using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 621, 长度 = 0, 注释 = "更多资金信息")]
	public sealed class 更多资金信息 : GamePacket
	{
		
		public 更多资金信息()
		{
			
			
		}
	}
}
