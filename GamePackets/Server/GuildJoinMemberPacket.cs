using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 592, Length = 54, Description = "GuildJoinMemberPacket")]
	public sealed class GuildJoinMemberPacket : GamePacket
	{
		
		public GuildJoinMemberPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 32)]
		public string 对象名字;

		
		[WrappingFieldAttribute(SubScript = 38, Length = 1)]
		public byte 对象职位;

		
		[WrappingFieldAttribute(SubScript = 39, Length = 1)]
		public byte 对象等级;

		
		[WrappingFieldAttribute(SubScript = 40, Length = 1)]
		public byte 对象职业;

		
		[WrappingFieldAttribute(SubScript = 41, Length = 1)]
		public byte CurrentMap;
	}
}
