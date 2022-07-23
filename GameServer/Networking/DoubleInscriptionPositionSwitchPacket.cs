using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 267, 长度 = 8, 注释 = "DoubleInscriptionPositionSwitchPacket")]
	public sealed class DoubleInscriptionPositionSwitchPacket : GamePacket
	{
		
		public DoubleInscriptionPositionSwitchPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort 当前栏位;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 2)]
		public ushort 第一铭文;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 第二铭文;
	}
}
