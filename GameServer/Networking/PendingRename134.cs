using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 103, 长度 = 2, 注释 = "玩家准备摆摊")]
	public sealed class 玩家准备摆摊 : GamePacket
	{
		
		public 玩家准备摆摊()
		{
			
			
		}
	}
}
