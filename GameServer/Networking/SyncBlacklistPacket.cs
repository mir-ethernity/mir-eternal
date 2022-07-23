using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 68, 长度 = 0, 注释 = "SyncBlacklistPacket")]
	public sealed class SyncBlacklistPacket : GamePacket
	{
		
		public SyncBlacklistPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节描述;
	}
}
