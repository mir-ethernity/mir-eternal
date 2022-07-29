using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 109, 长度 = 10, 注释 = "AddedSkillCooldownPacket")]
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
