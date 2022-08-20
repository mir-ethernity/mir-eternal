using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 248, Length = 6, Description = "EnterMartialArtsBatllefieldPacket")]
	public sealed class EnterMartialArtsBatllefieldPacket : GamePacket
	{
		
		public EnterMartialArtsBatllefieldPacket()
		{
			
			
		}
	}
}
