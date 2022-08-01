using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 161, 长度 = 0, 注释 = "SyncBoothDataPacket")]
	public sealed class SyncBoothDataPacket : GamePacket
	{
		
		public SyncBoothDataPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 0)]
		public byte[] 字节数据;
	}
}
