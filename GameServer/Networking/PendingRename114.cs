using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 154, 长度 = 2, 注释 = "玩家结束交易")]
	public sealed class 玩家结束交易 : GamePacket
	{
		
		public 玩家结束交易()
		{
			
			
		}
	}
}
