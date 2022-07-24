using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 349, 长度 = 14, 注释 = "SyncSkillCountPacket")]
	public sealed class SyncSkillCountPacket : GamePacket
	{
		
		public SyncSkillCountPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort SkillId;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte SkillCount;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public int 技能冷却;
	}
}
