using System;

namespace GameServer.Networking
{
	
	[PacketInfo(Source = PacketSource.Server, Id = 65, Length = 16, Description = "SyncNPCData")]
	public sealed class SyncNPCData : GamePacket
	{
		[WrappingField(SubScript = 2, Length = 4)]
		public int ObjectId;

		
		[WrappingField(SubScript = 6, Length = 2)]
		public ushort ObjectTemplate;

		
		[WrappingField(SubScript = 10, Length = 1)]
		public byte ObjectMass = 3;

		
		[WrappingField(SubScript = 11, Length = 1)]
		public byte ObjectClass;

		
		[WrappingField(SubScript = 12, Length = 4)]
		public int MaxHP;
	}
}
