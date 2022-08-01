using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 75, 长度 = 5, 注释 = "ToggleDoubleInscriptionBitPacket")]
	public sealed class ToggleDoubleInscriptionBitPacket : GamePacket
	{
		
		public ToggleDoubleInscriptionBitPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 装备类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 装备位置;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 操作参数;
	}
}
