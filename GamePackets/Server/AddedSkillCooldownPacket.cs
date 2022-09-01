using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 109, Length = 10, Description = "AddedSkillCooldownPacket")]
	public sealed class AddedSkillCooldownPacket : GamePacket
	{
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public int CoolingId;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int Cooldown;
	}
}
