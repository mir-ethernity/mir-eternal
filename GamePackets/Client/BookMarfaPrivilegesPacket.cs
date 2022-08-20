using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 217, Length = 3, Description = "BookMarfaPrivilegesPacket")]
	public sealed class BookMarfaPrivilegesPacket : GamePacket
	{
		
		public BookMarfaPrivilegesPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 特权类型;
	}
}
