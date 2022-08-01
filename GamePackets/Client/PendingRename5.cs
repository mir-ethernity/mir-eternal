using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 1003, 长度 = 6, 注释 = "删除角色")]
	public sealed class 客户删除角色 : GamePacket
	{
		
		public 客户删除角色()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
