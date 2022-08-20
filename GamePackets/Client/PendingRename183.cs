using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 539, Length = 6, Description = "同意收徒申请")]
	public sealed class 同意收徒申请 : GamePacket
	{
		
		public 同意收徒申请()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
