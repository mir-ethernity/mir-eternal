using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 72, 长度 = 7, 注释 = "SyncPetLevelPacket")]
	public sealed class SyncPetLevelPacket : GamePacket
	{
		
		public SyncPetLevelPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 宠物编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 宠物等级;
	}
}
