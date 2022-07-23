using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 10, 长度 = 6, 注释 = "更换角色")]
	public sealed class 客户更换角色 : GamePacket
	{
		
		public 客户更换角色()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 编号;
	}
}
