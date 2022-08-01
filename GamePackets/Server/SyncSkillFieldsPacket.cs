using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 19, 长度 = 0, 注释 = "SyncSkillFieldsPacket")]
	public sealed class SyncSkillFieldsPacket : GamePacket
	{
		
		public SyncSkillFieldsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 栏位描述;
	}
}
