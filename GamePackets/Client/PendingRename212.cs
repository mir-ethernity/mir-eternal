using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 558, 长度 = 7, 注释 = "处理入会申请")]
	public sealed class 处理入会申请 : GamePacket
	{
		
		public 处理入会申请()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 处理类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int 对象编号;
	}
}
