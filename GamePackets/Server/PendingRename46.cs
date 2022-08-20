using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 588, Length = 6, Description = "加入行会回应")]
	public sealed class 加入行会应答 : GamePacket
	{
		
		public 加入行会应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 行会编号;
	}
}
