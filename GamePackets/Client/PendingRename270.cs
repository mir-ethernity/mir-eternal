using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 572, 长度 = 5, 注释 = "更改存储权限")]
	public sealed class 更改存储权限 : GamePacket
	{
		
		public 更改存储权限()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte GuildJobs;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 原有位置;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 目标页面;
	}
}
