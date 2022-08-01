using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 90, 长度 = 4, 注释 = "CharacterRemoveSkillPacket")]
	public sealed class CharacterRemoveSkillPacket : GamePacket
	{
		
		public CharacterRemoveSkillPacket()
		{
			
			
		}
	}
}
