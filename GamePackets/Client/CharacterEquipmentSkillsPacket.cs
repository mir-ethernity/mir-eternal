using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 39, Length = 5, Description = "装备技能")]
	public sealed class CharacterEquipmentSkillsPacket : GamePacket
	{
		
		public CharacterEquipmentSkillsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 技能栏位;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 2)]
		public ushort SkillId;
	}
}
