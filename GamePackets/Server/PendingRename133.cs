using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 293, 长度 = 14, 注释 = "玩家重铸装备")]
	public sealed class 玩家重铸装备 : GamePacket
	{
		
		public 玩家重铸装备()
		{
			
			
		}
	}
}
