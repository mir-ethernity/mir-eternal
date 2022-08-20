using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 125, Length = 5, Description = "技能升级")]
	public sealed class 玩家技能升级 : GamePacket
	{
		
		public 玩家技能升级()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public ushort SkillId;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte SkillLevel;
	}
}
