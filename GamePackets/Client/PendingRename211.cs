using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 1004, Length = 6, Description = "彻底删除角色")]
	public sealed class 彻底删除角色 : GamePacket
	{
		
		public 彻底删除角色()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
