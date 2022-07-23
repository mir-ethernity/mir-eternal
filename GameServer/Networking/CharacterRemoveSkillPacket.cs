using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 90, 长度 = 4, 注释 = "CharacterRemoveSkillPacket")]
	public sealed class CharacterRemoveSkillPacket : GamePacket
	{
		
		public CharacterRemoveSkillPacket()
		{
			
			
		}
	}
}
