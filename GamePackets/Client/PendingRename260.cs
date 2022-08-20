using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 552, Length = 10, Description = "查询GuildName")]
	public sealed class 查询GuildName : GamePacket
	{
		
		public 查询GuildName()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 行会编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 状态编号;
	}
}
