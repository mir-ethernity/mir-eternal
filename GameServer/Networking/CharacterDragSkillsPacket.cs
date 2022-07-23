using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 100, 长度 = 7, 注释 = "CharacterDragSkillsPacket")]
	public sealed class CharacterDragSkillsPacket : GamePacket
	{
		
		public CharacterDragSkillsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 技能栏位;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 2)]
		public ushort 技能编号;

		
		[WrappingFieldAttribute(下标 = 5, 长度 = 1)]
		public byte 铭文编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 技能等级;
	}
}
