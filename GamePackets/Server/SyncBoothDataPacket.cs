using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 161, Length = 0, Description = "SyncBoothDataPacket")]
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
