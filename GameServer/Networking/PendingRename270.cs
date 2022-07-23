using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 572, 长度 = 5, 注释 = "更改存储权限")]
	public sealed class 更改存储权限 : GamePacket
	{
		
		public 更改存储权限()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte GuildJobs;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 原有位置;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 目标页面;
	}
}
