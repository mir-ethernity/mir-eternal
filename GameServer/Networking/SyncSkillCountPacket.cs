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
		public ushort 技能编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 技能计数;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public int 技能冷却;
	}
}
