using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 609, 长度 = 7, 注释 = "删除外交公告")]
	public sealed class 删除外交公告 : GamePacket
	{
		
		public 删除外交公告()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 外交类型;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 行会编号;
	}
}
