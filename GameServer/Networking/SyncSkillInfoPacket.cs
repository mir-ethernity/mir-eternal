using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 18, 长度 = 0, 注释 = "SyncSkillInfoPacket")]
	public sealed class SyncSkillInfoPacket : GamePacket
	{
		
		public SyncSkillInfoPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 技能描述;
	}
}
