using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 560, 长度 = 7, 注释 = "处理入会邀请")]
	public sealed class 处理入会邀请 : GamePacket
	{
		
		public 处理入会邀请()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 处理类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int 对象编号;
	}
}
