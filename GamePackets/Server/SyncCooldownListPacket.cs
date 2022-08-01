using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 108, 长度 = 0, 注释 = "SyncCooldownListPacket")]
	public sealed class SyncCooldownListPacket : GamePacket
	{
		
		public SyncCooldownListPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
