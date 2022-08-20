using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 1006, Length = 6, Description = "删除角色回应")]
	public sealed class 删除角色应答 : GamePacket
	{
		
		public 删除角色应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
