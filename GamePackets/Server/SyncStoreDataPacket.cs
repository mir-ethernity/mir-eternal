using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 142, 长度 = 0, 注释 = "同步商店版本")]
	public sealed class SyncStoreDataPacket : GamePacket
	{
		[WrappingField(SubScript = 4, Length = 4)]
		public int StoreVersion;

		
		[WrappingField(SubScript = 8, Length = 4)]
		public int ItemsCount;
		
		[WrappingField(SubScript = 12, Length = 0)]
		public byte[] Data = Array.Empty<byte>();
	}
}
