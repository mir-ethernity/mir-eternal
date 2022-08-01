using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 151, 长度 = 0, 注释 = "同步地面物品")]
	public sealed class 同步地面物品 : GamePacket
	{
		
		public 同步地面物品()
		{
			
			
		}
	}
}
