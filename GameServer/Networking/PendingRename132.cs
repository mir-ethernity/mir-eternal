using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 104, 长度 = 2, 注释 = "玩家重整摊位")]
	public sealed class 玩家重整摊位 : GamePacket
	{
		
		public 玩家重整摊位()
		{
			
			
		}
	}
}
