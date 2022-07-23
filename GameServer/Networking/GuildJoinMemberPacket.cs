using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 592, 长度 = 54, 注释 = "GuildJoinMemberPacket")]
	public sealed class GuildJoinMemberPacket : GamePacket
	{
		
		public GuildJoinMemberPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 32)]
		public string 对象名字;

		
		[WrappingFieldAttribute(下标 = 38, 长度 = 1)]
		public byte 对象职位;

		
		[WrappingFieldAttribute(下标 = 39, 长度 = 1)]
		public byte 对象等级;

		
		[WrappingFieldAttribute(下标 = 40, 长度 = 1)]
		public byte 对象职业;

		
		[WrappingFieldAttribute(下标 = 41, 长度 = 1)]
		public byte 当前地图;
	}
}
