using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 106, 长度 = 2, 注释 = "玩家收起摊位")]
	public sealed class 玩家收起摊位 : GamePacket
	{
		
		public 玩家收起摊位()
		{
			
			
		}
	}
}
