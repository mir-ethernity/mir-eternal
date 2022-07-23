using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 553, 长度 = 7, 注释 = "查看行会列表")]
	public sealed class 查看行会列表 : GamePacket
	{
		
		public 查看行会列表()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 查看方式;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 行会编号;
	}
}
