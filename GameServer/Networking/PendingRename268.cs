using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 1008, 长度 = 38, 注释 = "更改角色名字")]
	public sealed class 更改角色名字 : GamePacket
	{
		
		public 更改角色名字()
		{
			
			
		}
	}
}
