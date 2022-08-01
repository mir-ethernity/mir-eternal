using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 100, 长度 = 7, 注释 = "CharacterDragSkillsPacket")]
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
		public byte 技能等级;
	}
}
