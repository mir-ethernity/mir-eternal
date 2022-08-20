using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 560, Length = 7, Description = "处理入会邀请")]
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
