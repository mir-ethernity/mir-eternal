using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 109, Length = 10, Description = "AddedSkillCooldownPacket")]
	public sealed class AddedSkillCooldownPacket : GamePacket
	{
		
		public AddedSkillCooldownPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public int 冷却编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int Cooldown;
	}
}
