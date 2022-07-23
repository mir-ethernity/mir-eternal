using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 152, 长度 = 2, 注释 = "玩家确认交易")]
	public sealed class 玩家确认交易 : GamePacket
	{
		
		public 玩家确认交易()
		{
			
			
		}
	}
}
