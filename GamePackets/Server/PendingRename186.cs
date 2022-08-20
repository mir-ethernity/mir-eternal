using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 601, Length = 3, Description = "脱离行会应答")]
	public sealed class 脱离行会应答 : GamePacket
	{
		
		public 脱离行会应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public byte 脱离方式;
	}
}
