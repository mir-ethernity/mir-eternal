using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 126, 长度 = 6, 注释 = "SyncSkillExpPacket")]
	public sealed class SyncSkillExpPacket : GamePacket
	{
		
		public SyncSkillExpPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort SkillId;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 2)]
		public ushort 当前经验;
	}
}
