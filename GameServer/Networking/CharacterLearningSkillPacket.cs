using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 89, 长度 = 9, 注释 = "CharacterLearningSkillPacket")]
	public sealed class CharacterLearningSkillPacket : GamePacket
	{
		
		public CharacterLearningSkillPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 角色编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort SkillId;
	}
}
