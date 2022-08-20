using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 349, Length = 14, Description = "SyncSkillCountPacket")]
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
