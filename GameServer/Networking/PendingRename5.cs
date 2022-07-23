using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 1003, 长度 = 6, 注释 = "删除角色")]
	public sealed class 客户删除角色 : GamePacket
	{
		
		public 客户删除角色()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 角色编号;
	}
}
