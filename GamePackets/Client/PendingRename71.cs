using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 521, Length = 7, Description = "申请创建队伍")]
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
