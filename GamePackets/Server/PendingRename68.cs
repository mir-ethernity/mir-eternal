using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 605, Length = 6, Description = "申请结盟应答")]
	public sealed class 申请结盟应答 : GamePacket
	{
		
		public 申请结盟应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 行会编号;
	}
}
