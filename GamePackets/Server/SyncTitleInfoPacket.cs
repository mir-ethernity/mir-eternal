using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 24, 长度 = 0, 注释 = "SyncTitleInfoPacket")]
	public sealed class SyncTitleInfoPacket : GamePacket
	{
		
		public SyncTitleInfoPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
