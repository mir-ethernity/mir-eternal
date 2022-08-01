using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 1009, 长度 = 2, 注释 = "更换角色")]
	public sealed class 更换角色应答 : GamePacket
	{
		
		public 更换角色应答()
		{
			
			
		}
	}
}
