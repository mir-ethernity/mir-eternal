using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 557, Length = 12, Description = "申请收徒提示")]
	public sealed class 申请收徒提示 : GamePacket
	{
		
		public 申请收徒提示()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 面板类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 对象等级;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 4)]
		public int 对象声望;
	}
}
