using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 68, 长度 = 0, 注释 = "SyncBlacklistPacket")]
	public sealed class SyncBlacklistPacket : GamePacket
	{
		
		public SyncBlacklistPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
