using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 1003, Length = 6, Description = "删除角色")]
	public sealed class 客户删除角色 : GamePacket
	{
		
		public 客户删除角色()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
