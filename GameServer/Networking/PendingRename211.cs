using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 1004, 长度 = 6, 注释 = "彻底删除角色")]
	public sealed class 彻底删除角色 : GamePacket
	{
		
		public 彻底删除角色()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
