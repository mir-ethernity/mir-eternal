using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 126, 长度 = 6, 注释 = "SyncSkillExpPacket")]
	public sealed class SyncSkillExpPacket : GamePacket
	{
		
		public SyncSkillExpPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public ushort SkillId;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 2)]
		public ushort 当前经验;
	}
}
