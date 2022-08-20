using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 127, Length = 7, Description = "SyncSkillLevelPacket数据")]
	public sealed class SyncSkillLevelPacket : GamePacket
	{
		
		public SyncSkillLevelPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public ushort SkillId;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 2)]
		public ushort CurrentExp;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte CurrentRank;
	}
}
