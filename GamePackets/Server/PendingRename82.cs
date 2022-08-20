using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 558, Length = 6, Description = "同意收徒申请")]
	public sealed class 收徒申请同意 : GamePacket
	{
		
		public 收徒申请同意()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
