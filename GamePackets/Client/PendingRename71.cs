using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 521, 长度 = 7, 注释 = "申请创建队伍")]
	public sealed class 申请创建队伍 : GamePacket
	{
		
		public 申请创建队伍()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 分配方式;
	}
}
