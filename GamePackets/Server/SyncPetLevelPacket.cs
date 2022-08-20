using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 72, Length = 7, Description = "SyncPetLevelPacket", Broadcast = true)]
	public sealed class SyncPetLevelPacket : GamePacket
	{
		
		public SyncPetLevelPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 宠物编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 宠物等级;
	}
}
