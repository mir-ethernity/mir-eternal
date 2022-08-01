using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 18, 长度 = 0, 注释 = "SyncSkillInfoPacket")]
	public sealed class SyncSkillInfoPacket : GamePacket
	{
		
		public SyncSkillInfoPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 技能描述;
	}
}
