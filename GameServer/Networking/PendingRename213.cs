using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 560, 长度 = 7, 注释 = "处理入会邀请")]
	public sealed class 处理入会邀请 : GamePacket
	{
		
		public 处理入会邀请()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 处理类型;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 对象编号;
	}
}
