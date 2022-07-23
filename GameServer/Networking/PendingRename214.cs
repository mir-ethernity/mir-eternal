using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 583, 长度 = 7, 注释 = "处理解敌申请")]
	public sealed class 处理解敌申请 : GamePacket
	{
		
		public 处理解敌申请()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 回应类型;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 行会编号;
	}
}
