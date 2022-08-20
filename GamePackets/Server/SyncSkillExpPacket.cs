using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 126, Length = 6, Description = "SyncSkillExpPacket")]
	public sealed class SyncSkillExpPacket : GamePacket
	{
		
		public SyncSkillExpPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public ushort SkillId;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 2)]
		public ushort CurrentExp;
	}
}
