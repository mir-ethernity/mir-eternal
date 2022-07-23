using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 109, 长度 = 10, 注释 = "AddedSkillCooldownPacket")]
	public sealed class AddedSkillCooldownPacket : GamePacket
	{
		
		public AddedSkillCooldownPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public int 冷却编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int Cooldown;
	}
}
