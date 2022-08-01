using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 101, 长度 = 6, 注释 = "CharacterAssemblyInscriptionPacket")]
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
		public byte 技能等级;
	}
}
