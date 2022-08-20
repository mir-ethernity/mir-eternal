using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 570, Length = 7, Description = "处理结盟申请")]
	public sealed class 处理结盟申请 : GamePacket
	{
		
		public 处理结盟申请()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 处理类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int 行会编号;
	}
}
