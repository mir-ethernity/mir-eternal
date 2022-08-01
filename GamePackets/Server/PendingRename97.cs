using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 40, 长度 = 2, 注释 = "离开场景(包括商店/随机卷)")]
	public sealed class 玩家离开场景 : GamePacket
	{
		
		public 玩家离开场景()
		{
			
			
		}
	}
}
