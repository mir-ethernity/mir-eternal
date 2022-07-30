using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 39, 长度 = 5, 注释 = "装备技能")]
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
