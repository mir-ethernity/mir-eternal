using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 75, 长度 = 5, 注释 = "ToggleDoubleInscriptionBitPacket")]
	public sealed class ToggleDoubleInscriptionBitPacket : GamePacket
	{
		
		public ToggleDoubleInscriptionBitPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 装备类型;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 装备位置;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 操作参数;
	}
}
