using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 33, 长度 = 4, 注释 = "CharacterSwitchSkillsPacket")]
	public sealed class CharacterSwitchSkillsPacket : GamePacket
	{
		
		public CharacterSwitchSkillsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort SkillId;
	}
}
