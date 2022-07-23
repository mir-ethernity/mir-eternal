using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 183, 长度 = 2, 注释 = "玩家退出登录")]
	public sealed class 玩家退出登录 : GamePacket
	{
		
		public 玩家退出登录()
		{
			
			
		}
	}
}
