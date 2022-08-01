using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 267, 长度 = 8, 注释 = "DoubleInscriptionPositionSwitchPacket")]
	public sealed class DoubleInscriptionPositionSwitchPacket : GamePacket
	{
		
		public DoubleInscriptionPositionSwitchPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public ushort 当前栏位;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 2)]
		public ushort 第一铭文;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 2)]
		public ushort 第二铭文;
	}
}
