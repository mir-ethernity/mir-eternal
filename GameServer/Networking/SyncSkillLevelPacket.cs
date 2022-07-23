using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 127, 长度 = 7, 注释 = "SyncSkillLevelPacket数据")]
	public sealed class SyncSkillLevelPacket : GamePacket
	{
		
		public SyncSkillLevelPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort 技能编号;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 2)]
		public ushort 当前经验;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 当前等级;
	}
}
