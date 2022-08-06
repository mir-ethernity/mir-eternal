using System;

namespace GameServer.Networking
{
	
	[PacketInfo(来源 = PacketSource.Server, 编号 = 78, 长度 = 14, 注释 = "SyncObjectHP", Broadcast = true)]
	public sealed class SyncObjectHP : GamePacket
	{
		[WrappingField(SubScript = 2, Length = 4)]
		public int ObjectId;

		
		[WrappingField(SubScript = 6, Length = 4)]
		public int CurrentHP;

		
		[WrappingField(SubScript = 10, Length = 4)]
		public int MaxHP;
	}
}
