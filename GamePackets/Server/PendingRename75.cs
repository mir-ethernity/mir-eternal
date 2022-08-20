using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 642, Length = 10, Description = "申请Hostility应答")]
	public sealed class 申请Hostility应答 : GamePacket
	{
		
		public 申请Hostility应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 行会编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 需要资金;
	}
}
