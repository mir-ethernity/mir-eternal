using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 56, Length = 7, Description = "角色复活")]
	public sealed class 玩家角色复活 : GamePacket
	{
		
		public 玩家角色复活()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 复活方式;
	}
}
