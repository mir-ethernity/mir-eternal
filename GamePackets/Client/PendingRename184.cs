using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 535, Length = 6, Description = "同意拜师申请")]
	public sealed class 同意拜师申请 : GamePacket
	{
		
		public 同意拜师申请()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
