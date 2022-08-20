using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 543, Length = 3, Description = "收徒推送应答")]
	public sealed class 收徒推送应答 : GamePacket
	{
		
		public 收徒推送应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public bool 收徒推送;
	}
}
