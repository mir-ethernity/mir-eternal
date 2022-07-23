using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 108, 长度 = 0, 注释 = "SyncCooldownListPacket")]
	public sealed class SyncCooldownListPacket : GamePacket
	{
		
		public SyncCooldownListPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节描述;
	}
}
