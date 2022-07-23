using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 598, 长度 = 2, 注释 = "打开角色背包")]
	public sealed class 打开角色背包 : GamePacket
	{
		
		public 打开角色背包()
		{
			
			
		}
	}
}
