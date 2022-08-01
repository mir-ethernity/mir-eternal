using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 153, 长度 = 2, 注释 = "玩家解锁交易")]
	public sealed class 玩家解锁交易 : GamePacket
	{
		
		public 玩家解锁交易()
		{
			
			
		}
	}
}
