using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 100, Length = 7, Description = "CharacterDragSkillsPacket")]
	public sealed class CharacterDragSkillsPacket : GamePacket
	{
		
		public CharacterDragSkillsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 技能栏位;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 2)]
		public ushort SkillId;

		
		[WrappingFieldAttribute(SubScript = 5, Length = 1)]
		public byte Id;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte SkillLevel;
	}
}
