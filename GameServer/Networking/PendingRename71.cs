using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 521, 长度 = 7, 注释 = "申请创建队伍")]
	public sealed class 申请创建队伍 : GamePacket
	{
		
		public 申请创建队伍()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 分配方式;
	}
}
