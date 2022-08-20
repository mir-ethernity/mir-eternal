using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 19, Length = 0, Description = "SyncSkillFieldsPacket")]
	public sealed class SyncSkillFieldsPacket : GamePacket
	{
		
		public SyncSkillFieldsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 栏位描述;
	}
}
