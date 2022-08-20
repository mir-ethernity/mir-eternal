using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 101, Length = 6, Description = "CharacterAssemblyInscriptionPacket")]
	public sealed class CharacterAssemblyInscriptionPacket : GamePacket
	{
		
		public CharacterAssemblyInscriptionPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public ushort SkillId;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte Id;

		
		[WrappingFieldAttribute(SubScript = 5, Length = 1)]
		public byte SkillLevel;
	}
}
