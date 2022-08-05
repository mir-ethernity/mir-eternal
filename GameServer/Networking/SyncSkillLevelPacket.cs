using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 127, 长度 = 7, 注释 = "SyncSkillLevelPacket数据")]
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
