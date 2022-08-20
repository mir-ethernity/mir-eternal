using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 89, Length = 9, Description = "CharacterLearningSkillPacket")]
	public sealed class CharacterLearningSkillPacket : GamePacket
	{
		
		public CharacterLearningSkillPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 2)]
		public ushort SkillId;
	}
}
