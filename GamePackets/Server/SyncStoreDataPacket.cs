using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 142, Length = 0, Description = "同步商店版本")]
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
