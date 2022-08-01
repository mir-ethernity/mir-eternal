using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 153, 长度 = 0, 注释 = "同步道具列表")]
	public sealed class 同步道具列表 : GamePacket
	{
		
		public 同步道具列表()
		{
			
			
		}
	}
}
