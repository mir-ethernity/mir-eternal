using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 349, 长度 = 14, 注释 = "SyncSkillCountPacket")]
	public sealed class SyncSkillCountPacket : GamePacket
	{
		
		public SyncSkillCountPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public ushort SkillId;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte SkillCount;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 4)]
		public int 技能冷却;
	}
}
