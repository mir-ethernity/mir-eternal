using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 72, 长度 = 7, 注释 = "SyncPetLevelPacket")]
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
