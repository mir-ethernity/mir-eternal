using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 73, 长度 = 4, 注释 = "ReplaceAdvancedInscriptionPacket")]
	public sealed class ReplaceAdvancedInscriptionPacket : GamePacket
	{
		
		public ReplaceAdvancedInscriptionPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 装备类型;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 装备位置;
	}
}
