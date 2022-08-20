using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 87, Length = 6, Description = "CharacterSynthesisItemPacket")]
	public sealed class CharacterSynthesisItemPacket : GamePacket
	{
		
		public CharacterSynthesisItemPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte Id;
	}
}
