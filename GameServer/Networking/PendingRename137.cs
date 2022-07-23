using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 146, 长度 = 2, 注释 = "玩家卸下称号")]
	public sealed class 玩家卸下称号 : GamePacket
	{
		
		public 玩家卸下称号()
		{
			
			
		}
	}
}
