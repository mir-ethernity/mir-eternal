using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 125, 长度 = 5, 注释 = "技能升级")]
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
