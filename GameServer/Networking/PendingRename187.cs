using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 247, 长度 = 2, 注释 = "刷新演武挑战")]
	public sealed class 刷新演武挑战 : GamePacket
	{
		
		public 刷新演武挑战()
		{
			
			
		}
	}
}
