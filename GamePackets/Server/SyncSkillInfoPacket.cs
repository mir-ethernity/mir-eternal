using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 18, Length = 0, Description = "SyncSkillInfoPacket")]
	public sealed class SyncSkillInfoPacket : GamePacket
	{
		
		public SyncSkillInfoPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 技能描述;
	}
}
