using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 553, 长度 = 7, 注释 = "查看行会列表")]
	public sealed class 查看行会列表 : GamePacket
	{
		
		public 查看行会列表()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 查看方式;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int 行会编号;
	}
}
