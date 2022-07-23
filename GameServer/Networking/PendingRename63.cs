using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 557, 长度 = 12, 注释 = "申请收徒提示")]
	public sealed class 申请收徒提示 : GamePacket
	{
		
		public 申请收徒提示()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 面板类型;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 对象等级;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int 对象声望;
	}
}
