using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 151, 长度 = 2, 注释 = "玩家锁定交易")]
	public sealed class 玩家锁定交易 : GamePacket
	{
		
		public 玩家锁定交易()
		{
			
			
		}
	}
}
